using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Playwright;
using PlaywrightTests.Locators;

namespace PlaywrightTests.Pages;

public class ProductsCheckoutPage : ProductsCheckoutLocators
{
    public ProductsCheckoutPage(IPage page) : base(page)
    {
    }
    public async Task AddToCartMethod()
    {
        await Click(AddToCartButton);
        await Click(CartLogo);
        await Click(CheckOut);
    }

    public async Task CheckoutPage(string firstname, string lastname, string postalcode)
    {
        await FillText(FirstName, firstname);
        await FillText(LasstName, lastname);
        await FillText(PostalCode, postalcode);
        await Click(Continuebtn);
        await Click(Finishbtn);
        await Click(BackHomebtn);
    }
}