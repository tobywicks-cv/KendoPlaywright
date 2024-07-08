using Microsoft.Playwright;
using System.Reflection.Metadata;

namespace KendoE2ETesting;

public class KendoDropdown
{
    [Fact]
    public async Task DropDownTest()
    {
        await PlaywrightExtensions2.ForNewPage(async page =>
        {
            //https://demos.telerik.com/kendo-ui/dropdownlist/index
            // span.k-input-button
            // document.querySelector('.k-dropdownlist')

            await page.GotoAsync("https://demos.telerik.com/kendo-ui/dropdownlist/index");
            var downdown = page.Locator(".k-dropdownlist");

            var dropdownButton = downdown.Locator("span.k-input-button");
            await dropdownButton.ClickAsync();

            // PROBLEM: This won't work if there are multiple dropdowns open simultaneously!
            var dropdownList = page.Locator(".k-dropdownlist-popup");
            
            // https://playwright.dev/docs/other-locators
            var berlin = dropdownList.Locator(@"li:has(span:has-text(""Berlin""))");
            await berlin.ClickAsync(new LocatorClickOptions());

            await Task.Delay(5000);
        });

    }

    [Fact]
    public async Task DropDownTest_WORKS()
    {
        await PlaywrightExtensions2.ForNewPage(async page =>
        {
            //https://demos.telerik.com/kendo-ui/dropdownlist/index
            // span.k-input-button
            // document.querySelector('.k-dropdownlist')

            await page.GotoAsync("https://demos.telerik.com/kendo-ui/dropdownlist/index");
            var dropDownButton = page.Locator("span.k-input-button");
            await dropDownButton.ClickAsync();

            var dropdownList = page.Locator(".k-list-content");
            // https://playwright.dev/docs/other-locators
            //var berlin = dropdownList.Locator(@"span:has-text(""Berlin"")");
            var berlin = dropdownList.Locator(@"li[data-offset-index='3']");
            await berlin.ClickAsync(new LocatorClickOptions()
            {
                Force = true,
            });

            await Task.Delay(5000);
        });

    }
}