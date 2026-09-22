using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Pages.SauceDemo
{
    public class DemoLoginPage
    {
        private readonly IPage Page;

        private ILocator UserNameInput => Page.Locator("[data-test='username']");
        private ILocator PasswordInput => Page.Locator("[data-test='password']");
        private ILocator LoginButton => Page.Locator("[data-test='login-button']");
        private ILocator ErrorMessageLabel => Page.Locator("[data-test='error']");

        public DemoLoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task FillLoginFormAsync(string username, string password)
        {
            await UserNameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        public async Task<string> GetTextFromErrorLabelAsync()
        {
            return await ErrorMessageLabel.TextContentAsync();
        }
    }
}
