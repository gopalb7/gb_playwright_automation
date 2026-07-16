using AventStack.ExtentReports.Model;
using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;
using PlaywrightTests.Utilities;

namespace PlaywrightTests.Tests;

//[TestFixture]

public class LoginTests : BaseTest
{
    [Test]
    [Category("smoke")]
    public async Task VerifySuccessfulLogin()
    {
        //ReportManager.Test = ReportManager.Extent.CreateTest("Verify Successful Login");
        var loginPage = new LoginPage(Page);
        
        await loginPage.NavigationToLoginPage();
        await loginPage.Login(TestData.Username, TestData.Password);

        Console.WriteLine("Verifying user is on Inventory page...");
        Assert.That(Page.Url, Does.Contain("inventory"));
        Console.WriteLine("Assertion Passed: User is on Inventory page.");

        var inventoryTitle = Page.Locator(".title");
        Console.WriteLine("Before Inventory Assersion passed");

        Assert.That(
        await inventoryTitle.TextContentAsync(),
        Is.EqualTo("Products"));
        Console.WriteLine("Before Inventory Assersion passed " +inventoryTitle);
        ReportManager.Test.Info("Navigated to VerifySuccessfulLogin Test");
        
    }
}