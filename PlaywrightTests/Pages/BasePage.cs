using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public async Task Navigate(string url)
    {
        try{

            Console.WriteLine($"Navigating to URL: {url}");
            await Page.GotoAsync(url);
            Console.WriteLine($"Successfully Navigated to: {url}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"ERROR: Failed to navigate to URL '{url}'. Error: {ex.Message}");
            throw;
        }
    }

    public async Task Click(ILocator locator)
    {
        try
        {
            Console.WriteLine("Attempting to click element...");
            await locator.ClickAsync();
            Console.WriteLine("Element clicked successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"ERROR: Failed to click element. Error: {ex.Message}");
            throw;
        }
    }

    public async Task FillText(ILocator locator, string value)
    {
        try
    {
        Console.WriteLine($"Entering text: '{value}'");
        await locator.FillAsync(value);
        Console.WriteLine($"Successfully entered text: '{value}'");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: Failed to enter text '{value}'. Error: {ex.Message}");
        throw;
    }
    }

}