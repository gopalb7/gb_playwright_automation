using Microsoft.Playwright;
using PlaywrightTests.Locators;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Pages;

    public class MultiProductsPage : MultiProductsLocators
{
    public MultiProductsPage(IPage page) : base(page)
    {
    }

    public async Task AddToCart()
    {
        await Click(Products("backpack"));
        await Click(Products("bike-light"));
        await Click(Products("onesie"));
        await Click(FourthProduct);
        await Click(Products("fleece-jacket"));
    }

    public async Task GoToCart()
    {
        await Click(Cartbtn);
        await Click(RemoveOneSie);
        await Click(RemoveFleeceJacket);
        await Click(ContinueShopping);
    }

    public async Task AddAnotherProduct ()
    {
        //await Click(AddSixthProduct);
        await Click(Products("bolt-t-shirt"));
    }

    public async Task Checkout(string firstname, string lastname, string postalcode)
    {
        await Click(Cartbtn);
        await Click(CheckOut);
        await FillText(FirstName, firstname);
        await FillText(LasstName, lastname);
        await FillText(PostalCode, postalcode);
    }


    public async Task Finish()
    {
        await Click(Continuebtn);
        await Click(Finishbtn);    
        
    }

    public async Task<string> GetOrderConfirmationText()
    {
        return await OrderConfirmationMessage.TextContentAsync()?? string.Empty;
    }

   


    public async Task LogOut()
    {
         await Click(BackHomebtn);
        await Click(MenuButton);
        await Click(LogoutBtn);
    }

    

}