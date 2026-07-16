using Microsoft.Playwright;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;



namespace PlaywrightTests.Locators;
public class ProductsCheckoutLocators : BasePage
{
    public ProductsCheckoutLocators(IPage page) : base(page)
    {
    }

    
    protected ILocator AddToCartButton => Page.Locator("//*[@id='add-to-cart-sauce-labs-backpack']"); //Click
    protected ILocator CartLogo => Page.Locator("#shopping_cart_container");
    protected ILocator CheckOut => Page.Locator("#checkout");
    protected ILocator FirstName => Page.Locator("#first-name");
    protected ILocator LasstName => Page.Locator("#last-name");
    protected ILocator PostalCode => Page.Locator("#postal-code");
    protected ILocator Continuebtn => Page.Locator("#continue");
    protected ILocator Finishbtn => Page.Locator("#finish");
    protected ILocator BackHomebtn => Page.Locator("#back-to-products");


}