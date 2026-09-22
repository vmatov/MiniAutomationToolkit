using AQAProject.Pages.DemoQA;
using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests.UITests
{
    public class DemoQATest : BaseTest
    {
        [Test]
        public async Task Test001_CheckDropdown()
        {
            SelectMenuPage selectMenuPage = new SelectMenuPage(Page);
            var option = "Prof.";

            await selectMenuPage.OpenSelectMenuPage();
            await selectMenuPage.SelectOptionFromSelectOneDropdown(option);


        }
    }
}
