using AventStack.ExtentReports.Model;
using Microsoft.Playwright;
using PlaywrightTests.Utilities;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Locators;
public class MultiProductsLocators : BasePage
{
    public MultiProductsLocators(IPage page) : base(page)
    {
    }
    
    protected ILocator Products(string productName) => Page.Locator($"//*[@id='add-to-cart-sauce-labs-{productName}']");
    protected ILocator FourthProduct => Page.Locator("//*[@id='add-to-cart-test.allthethings()-t-shirt-(red)']");
    protected ILocator Cartbtn => Page.Locator("//*[@id='shopping_cart_container']");
    protected ILocator RemoveOneSie => Page.Locator("//*[@id='remove-sauce-labs-onesie']");
    protected ILocator RemoveFleeceJacket => Page.Locator("//*[@id='remove-sauce-labs-fleece-jacket']");
    protected ILocator ContinueShopping => Page.Locator("//*[@id='continue-shopping']");
    protected ILocator CheckOut => Page.Locator("#checkout");
    protected ILocator FirstName => Page.Locator("#first-name");
    protected ILocator LasstName => Page.Locator("#last-name");
    protected ILocator PostalCode => Page.Locator("#postal-code");
    protected ILocator Continuebtn => Page.Locator("#continue");
    protected ILocator Finishbtn => Page.Locator("#finish");
    protected ILocator BackHomebtn => Page.Locator("#back-to-products");
    protected ILocator OrderConfirmationMessage => Page.Locator(".complete-header");
    protected ILocator MenuButton => Page.Locator("#react-burger-menu-btn");
    protected ILocator LogoutBtn => Page.Locator("#logout_sidebar_link");



}