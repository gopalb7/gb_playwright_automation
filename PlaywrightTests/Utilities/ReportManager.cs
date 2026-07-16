using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlaywrightTests.Utilities;

public static class ReportManager
{
    public static ExtentReports Extent = null!;
    public static ExtentTest Test = null!;
    public static string ReportPath = null!;
    public static string ReportsDirectory = null!;

    public static void InitializeReport()
    {
        try
        {
            // Navigate from bin\Debug\net10.0 back to project root, then to Reports
            ReportsDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Reports"));
            Directory.CreateDirectory(ReportsDirectory);
            ReportPath = Path.Combine(ReportsDirectory, "TestReport.html");

            Console.WriteLine($"[ReportManager] Reports Directory: {ReportsDirectory}");
            Console.WriteLine($"[ReportManager] Report Path: {ReportPath}");

            var sparkReporter = new ExtentSparkReporter(ReportPath);

            Extent = new ExtentReports();
            Extent.AttachReporter(sparkReporter);
            Console.WriteLine("[ReportManager] Report initialized successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ReportManager] Error initializing report: {ex.Message}");
            throw;
        }
    }

    public static void FlushReport()
    {
        Extent.Flush();
    }
}