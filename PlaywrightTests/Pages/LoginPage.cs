using AventStack.ExtentReports.Model;
using Microsoft.Playwright;
using PlaywrightTests.Utilities;
using PlaywrightTests.Locators;

namespace PlaywrightTests.Pages;

public class LoginPage : LoginPageLocators
{
    public LoginPage(IPage page) : base(page){
    }

    public async Task NavigationToLoginPage()
    {
        //await Page.GotoAsync(TestData.BaseUrl);
        await Navigate(TestData.BaseUrl);
    }

    public async Task Login(string username, string password)
    {
        await FillText(UserName, username);
        await FillText(Password, password);
        Console.WriteLine("Before Click");
        await Click(LoginButton) ;
        Console.WriteLine("After Click");
        

    }


}
