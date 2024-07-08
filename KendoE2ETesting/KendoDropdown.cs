using Microsoft.Playwright;
using System.Reflection.Metadata;

namespace KendoE2ETesting;

public class KendoDropdown
{
    [Fact]
    public async Task DropDownTestv2()
    {
        await PlaywrightExtensions2.ForNewPage(async page =>
        {
            await page.GotoAsync("https://demos.telerik.com/kendo-ui/dropdownlist/index");
            var downdown = page.Locator(".k-dropdownlist");

            var dropdownButton = downdown.Locator("span.k-input-button");
            await dropdownButton.ClickAsync();

            // PROBLEM: This will not work if there are multiple dropdowns open simultaneously!
            // But should not really be an issue if entering values into dropdowns sequentially.
            var dropdownList = page.Locator(".k-list-content");

            // https://playwright.dev/docs/other-locators
            var item = dropdownList.Locator(@"li:has(span:has-text(""Paris""))");
            await item.ScrollIntoViewIfNeededAsync();
            await item.ClickAsync(new LocatorClickOptions());

            await Task.Delay(5000);
        });
    }



    [Fact]
    public async Task DropDownSelectByTyping()
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
            await Task.Delay(1000);

            var dropdownList = page.Locator(".k-dropdownlist-popup");
            var input = dropdownList.Locator(".k-input-inner");
            await input.FillAsync("Berlin");
            await page.Keyboard.PressAsync("Enter");

            await Task.Delay(5000);
        });
    }

    [Fact]
    public async Task DropDownTestv2_scrollintoview_workswhendebuggingslowly____()
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
            //var dropdownList = page.Locator(".k-dropdownlist-popup");
            var dropdownList = page.Locator(".k-list-content");

            // https://playwright.dev/docs/other-locators
            var berlin = dropdownList.Locator(@"li:has(span:has-text(""Berlin""))");
            await berlin.ScrollIntoViewIfNeededAsync();
            await berlin.ClickAsync(new LocatorClickOptions());

            await Task.Delay(5000);
        });
    }

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
            //var dropdownList = page.Locator(".k-dropdownlist-popup");
            var dropdownList = page.Locator(".k-list-content");

            // https://playwright.dev/docs/other-locators
            //var berlin = dropdownList.Locator(@"li:has(span:has-text(""Berlin""))");
            var berlin = dropdownList.Locator(@"li[data-offset-index='3']");
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

            await Task.Delay(5000);

            var dropdownList = page.Locator(".k-list-content");
            // https://playwright.dev/docs/other-locators
            //var berlin = dropdownList.Locator(@"span:has-text(""Berlin"")");
            var berlin = dropdownList.Locator(@"li[data-offset-index='1']");
            await berlin.ClickAsync(new LocatorClickOptions());

        });
    }

    [Fact]
    public async Task DropDownTest_WORKS_NeedsDelayAfterLoadingPopup()
    {
        await PlaywrightExtensions2.ForNewPage(async page =>
        {
            //https://demos.telerik.com/kendo-ui/dropdownlist/index
            // span.k-input-button
            // document.querySelector('.k-dropdownlist')

            await page.GotoAsync("https://demos.telerik.com/kendo-ui/dropdownlist/index");
            var dropDownButton = page.Locator("span.k-input-button");
            await dropDownButton.ClickAsync();

            //await Task.Delay(5000);

            var dropdownList = page.Locator(".k-list-content");
            // https://playwright.dev/docs/other-locators
            //var berlin = dropdownList.Locator(@"span:has-text(""Berlin"")");
            var berlin = dropdownList.Locator(@"li[data-offset-index='1']");
            await berlin.ClickAsync(new LocatorClickOptions());

            await Task.Delay(3000);
        });
    }
}