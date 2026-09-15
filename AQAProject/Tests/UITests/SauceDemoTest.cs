using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests.UITests
{
    public class SauceDemoTest : BaseTest
    {
        [Test]
        public async Task Test001_CheckAuthorisation()
        {
            var baseUrl = "https://www.saucedemo.com/";
            var userName = "standard_user";
            var password = "secret_sauce";

            await Page.GotoAsync(baseUrl);
            await Page.Locator("[data-test='username']").FillAsync(userName);
            await Page.Locator("[data-test='password']").FillAsync(password); 
            await Page.Locator("[data-test='login-button']").ClickAsync();

            Page.Url.Should().Be(baseUrl + "inventory.html");
            var inventoryTitle = await Page.Locator("[data-test='title']").TextContentAsync();
            inventoryTitle.Should().Be("Products");
        }

    }
}
