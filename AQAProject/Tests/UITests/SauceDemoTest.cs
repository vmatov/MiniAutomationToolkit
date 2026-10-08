using AQAProject.DataProvider;
using AQAProject.Pages.SauceDemo;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework.Internal;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests.UITests
{
    [TestFixture]
    public class SauceDemoTest : BaseTest
    {
        [Test]
        public async Task Test001_CheckAuthorisation()
        {
            DemoLoginPage loginPage = new DemoLoginPage(Page);

            var baseUrl = "https://www.saucedemo.com/";
            var userName = "standard_user";
            var password = "secret_sauce";

            await loginPage.OpenLoginPageAsync();
            await loginPage.FillLoginFormAsync(userName, password);

            Page.Url.Should().Be(baseUrl + "inventory.html");
            var inventoryTitle = await Page.Locator("[data-test='title']").TextContentAsync();
            inventoryTitle.Should().Be("Products");
        }

        [Test]
        public async Task Test002_CheckAddingItemsToCart()
        {
            // Проходим авторизацию
            DemoLoginPage loginPage = new DemoLoginPage(Page);
            InventoryPage inventoryPage = new InventoryPage(Page);
            var userName = "standard_user";
            var password = "secret_sauce";
            await loginPage.OpenLoginPageAsync();
            await loginPage.FillLoginFormAsync(userName, password);

            // Выполняем действия на странице inventory
            List<string> itemsToAdd = new List<string> { "Sauce Labs Bolt T-Shirt", "Sauce Labs Bike Light" };
            (await inventoryPage.CheckUrlPageAsync()).Should().BeTrue();
            foreach (var item in itemsToAdd)
            {
                await inventoryPage.AddItemByName(item);
            }
            await inventoryPage.ClickCartItem();

            // Проверяем страницу корзины
            CartPage cartPage = new CartPage(Page);
            foreach (var item in itemsToAdd)
            {
                await cartPage.CheckItemByName(item);
            }
            await cartPage.ClickCheckoutBtn();

            // Заполняем форму на странице checkout
            CheckoutPage checkoutPage = new CheckoutPage(Page);
            await checkoutPage.FillCheckoutFormAsync("Test", "Testus", "12345");
            foreach (var item in itemsToAdd)
            {
                await cartPage.CheckItemByName(item);
            }
            await checkoutPage.ClickFinishBtn();
            await checkoutPage.CheckCompleateHeaderAsync();
        }

        [TestCaseSource(typeof(EmailProvider),
            nameof(EmailProvider.GetLoginCases))]
        public async Task Test003_CheckAuthorisationForMultipleUsers(string login, string password)
        {
            DemoLoginPage loginPage = new DemoLoginPage(Page);
            InventoryPage inventoryPage = new InventoryPage(Page);

            await loginPage.OpenLoginPageAsync();


            await loginPage.OpenLoginPageAsync();
            await loginPage.FillLoginFormAsync(login, password);
            await inventoryPage.CheckIfPageLoaded();

        }
    }
}
