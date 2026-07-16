using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;
using PlaywrightTests.Utilities;

namespace PlaywrightTests.Tests;

[TestFixture]

public class ProductsTests : BaseTest
{
    private ProductsCheckoutPage _productsCheckoutPage;
    private MultiProductsPage _multiProductsPage;

    [SetUp]

    public async Task ProductSetup()
    {

        _productsCheckoutPage = new ProductsCheckoutPage(Page);
        _multiProductsPage = new MultiProductsPage(Page);
        var loginPage = new LoginPage(Page);

        await loginPage.NavigationToLoginPage();
        await loginPage.Login(TestData.Username, TestData.Password);

        Console.WriteLine("Starting product test......");
    }


    [Test]
    [Category("Regression")]
    //[Order(1)]
    public async Task ProduProductAddToCart_ShouldCheckoutSuccessfully()
    {
        await _productsCheckoutPage.AddToCartMethod();
        await _productsCheckoutPage.CheckoutPage("New QA", "User GB", "150626");

        Assert.That(Page.Url, Does.Contain("inventory"));
        ReportManager.Test.Info("Navigated to ProduProductAddToCart_ShouldCheckoutSuccessfully Test");
    }


    [Test]
    [Category("Integration")]

    public async Task AddMultiPrAddMultipleProductsAndCheckoutoducts()
    {
        //ReportManager.Test = ReportManager.Extent.CreateTest("AddMultiProducts");
        var multiProductsPage = new MultiProductsPage(Page);
        await multiProductsPage.AddToCart();
        await multiProductsPage.GoToCart();
        await multiProductsPage.AddAnotherProduct();
        await multiProductsPage.Checkout("Gopal", "QA Test", "211020");
        await multiProductsPage.Finish();
        //ReportManager.Test.Info("Verified multiple product checlout");

        string actualText = await multiProductsPage.GetOrderConfirmationText();
         Assert.That(actualText,Is.EqualTo("Thank you for your order!!"));
        await multiProductsPage.LogOut();


        ReportManager.Test.Info("Navigated to AddMultiPrAddMultipleProductsAndCheckoutoducts Test");
    }




}