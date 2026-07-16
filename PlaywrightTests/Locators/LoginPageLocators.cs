using Microsoft.Playwright;
using PlaywrightTests.Pages;// or the namespace where BasePage is defined

namespace PlaywrightTests.Locators;

public class LoginPageLocators : BasePage
{
    public LoginPageLocators(IPage page) : base(page)
    {
    }

    protected ILocator UserName => Page.Locator("#user-name");
    protected ILocator Password => Page.Locator("#password");
    protected ILocator LoginButton => Page.Locator("#login-button");
    protected ILocator LoginButton2 => Page.Locator("#login-button2");
}