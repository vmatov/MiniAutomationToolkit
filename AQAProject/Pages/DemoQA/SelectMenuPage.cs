using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Pages.DemoQA
{
    public class SelectMenuPage
    {

        private readonly IPage Page;

        private ILocator SelectOneDropdown => Page.Locator("[id='selectOne']");
        private ILocator SelectOneDropdownValue => SelectOneDropdown.Locator("[class*='singleValue']");
        private ILocator SelectOneDropdownOption => Page.Locator("[role='option']");
        

        public SelectMenuPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenSelectMenuPage()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");
        }

        public async Task SelectOptionFromSelectOneDropdown(string option)
        {
            await SelectOneDropdown.ClickAsync();
            await SelectOneDropdownOption.Filter(new() { HasText = option }).ClickAsync();
            await Assertions.Expect(SelectOneDropdownValue).ToHaveTextAsync(option);
        }
    }
}
