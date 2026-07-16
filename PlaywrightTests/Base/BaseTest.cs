using Microsoft.Playwright;
using PlaywrightTests.Utilities;
using DotNetEnv;


namespace PlaywrightTests.Base;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        ReportManager.InitializeReport();

        string environment =
            Environment.GetEnvironmentVariable("TEST_ENV") ??
            TestContext.Parameters.Get("Environment", "test");
        var envPath = Path.Combine(AppContext.BaseDirectory, $".env.{environment}");
        Env.Load(envPath);

        Console.WriteLine($"Base URL:===================={environment}");
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
    }
    [SetUp]
    public async Task BrowserSetup()
    {
        ReportManager.Test = ReportManager.Extent.CreateTest(TestContext.CurrentContext.Test.Name);

        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 500
            });

        Page = await Browser.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await CaptureScreenshotOnFailureAsync();
        ReportManager.FlushReport();

        await Browser.CloseAsync(); //Close the browsers
        Playwright.Dispose(); //This cleans up Playwright resources from memory
    }

    private async Task CaptureScreenshotOnFailureAsync()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            ReportManager.Test.Pass("Test Passed");
            return;
        }

        if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            try
            {
                if (string.IsNullOrEmpty(ReportManager.ReportsDirectory))
                {
                    ReportManager.Test.Warning("Reports directory not initialized");
                    ReportManager.Test.Fail(TestContext.CurrentContext.Result.Message);
                    return;
                }

                var screenshotDirectory = Path.Combine(ReportManager.ReportsDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotDirectory);

                var screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var screenshotPath = Path.Combine(screenshotDirectory, screenshotFileName);

                if (Page != null)
                {
                    await Page.ScreenshotAsync(new PageScreenshotOptions
                    {
                        Path = screenshotPath,
                        FullPage = true
                    });

                    ReportManager.Test.AddScreenCaptureFromPath(screenshotPath);
                    Console.WriteLine($"Screenshot captured: {screenshotPath}");
                }
            }
            catch (Exception ex)
            {
                ReportManager.Test.Warning($"Unable to capture screenshot: {ex.Message}");
            }

            ReportManager.Test.Fail(TestContext.CurrentContext.Result.Message);
        }
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        ReportManager.FlushReport();
    }
}