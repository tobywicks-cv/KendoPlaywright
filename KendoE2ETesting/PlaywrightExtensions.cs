using Microsoft.Playwright;
using PW = Microsoft.Playwright;

namespace KendoE2ETesting;

public static class PlaywrightExtensions2
{
    public static async Task ForNewPage(Func<IPage, Task> action)
    {
        var browserTypeLaunchOptions = new PW::BrowserTypeLaunchOptions()
        {
            Headless = false,
        };

        using var playwright = await PW::Playwright.CreateAsync();

        using var browserTask = playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);
        var browser = await browserTask;
        var page = await browser.NewPageAsync(new BrowserNewPageOptions()
        {
            ViewportSize = ViewportSize.NoViewport
        });

        await action(page);
    }
}
