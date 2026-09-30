using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Pages.SauceDemo
{
    public class InventoryPage
    {
        private readonly IPage Page;
        private ILocator CartIcon => Page.Locator("[data-test='shopping-cart-link']");
        private ILocator InventoryItem => Page.Locator(".inventory_item");

        private string url = "https://www.saucedemo.com/inventory.html";

        public InventoryPage(IPage page)
        {
            Page = page;
        }

        public async Task<bool> CheckUrlPageAsync()
        {
            return Page.Url == url;
        }

        public async Task AddItemByName(string name)
        {
            await InventoryItem
                .Filter(new() { HasText = name })
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();
        }
        public async Task ClickCartItem()
        {
            await CartIcon.ClickAsync();
        }
    }
}

