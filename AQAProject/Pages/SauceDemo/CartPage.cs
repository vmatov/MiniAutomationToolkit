using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Pages.SauceDemo
{
    public class CartPage
    {
        private readonly IPage Page;

        private ILocator CheckoutBtn => Page.Locator("[data-test='checkout']");



        public CartPage(IPage page)
        {
            Page = page;
        }

        public async Task CheckItemByName(string name)
        {
            await Assertions.Expect(Page.Locator(".cart_item").Filter(new() { HasText = name })).ToBeVisibleAsync();
        }

        public async Task ClickCheckoutBtn()
        {
            await CheckoutBtn.ClickAsync();
        }
    }
}
