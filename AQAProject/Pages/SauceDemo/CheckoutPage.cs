using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Pages.SauceDemo
{
    public class CheckoutPage
    {
        private readonly IPage Page;

        private ILocator FirstNameInput => Page.Locator("[data-test='firstName']");
        private ILocator LastNameInput => Page.Locator("[data-test='lastName']");
        private ILocator PostalCodeInput => Page.Locator("[data-test='postalCode']");
        private ILocator ContinueButton => Page.Locator("[data-test='continue']");
        private ILocator FinishButton => Page.Locator("[data-test='finish']");
        private ILocator CompleateHeader => Page.Locator("[data-test='complete-header']");

        public CheckoutPage(IPage page)
        {
            Page = page;
        }

        public async Task FillCheckoutFormAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await PostalCodeInput.FillAsync(postalCode);
            await ContinueButton.ClickAsync();
        }

        public async Task ClickFinishBtn()
        {
            await FinishButton.ClickAsync();
        }

        public async Task CheckCompleateHeaderAsync()
        {
            await Assertions.Expect(CompleateHeader).ToBeVisibleAsync();
            await Assertions.Expect(CompleateHeader).ToHaveTextAsync("Thank you for your order!");
        }
    }
}
