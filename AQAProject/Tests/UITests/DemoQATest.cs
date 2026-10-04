using AQAProject.Enums;
using AQAProject.Pages.DemoQA;
using AQAProject.Storages.ForUI.Builders;
using AQAProject.Storages.ForUI.Models;
using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests.UITests
{
    [TestFixture]
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
        [Test]
        public async Task FillStudentRegistrationForm()
        {
            await Page.GotoAsync("https://demoqa.com/automation-practice-form");

            StudentRegistrationBuilder builder = new StudentRegistrationBuilder();
            var studentData = builder.WithFirstName("Rajesh")
                .WithLastName("Kutrapalli")
                .WithGender(GenderType.Male)
                .Build();
            await FillAllFormFieldAsync(studentData);
        }

        //ЭТО В КЛАССЕ СТРАНИЦЫ, ПО ВСЕМ ПРАВИЛАМ!
        //ТУТ ЭТО ДЛЯ ДЕМОНСТРАЦИИ, КАК РАБОТАТЬ С ПАТТЕРНОМ И КАК ПЕРЕДАВАТЬ ДАННЫЕ
        public async Task FillAllFormFieldAsync(StudentRegistrationFormModel studentData)
        {
            await Page.Locator("#firstName").FillAsync(studentData.FirstName);
            await Page.Locator("#lastName").FillAsync(studentData.LastName);
        }
    }
}
