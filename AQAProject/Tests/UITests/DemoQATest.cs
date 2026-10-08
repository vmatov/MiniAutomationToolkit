using AQAProject.Enums;
using AQAProject.Pages.DemoQA;
using AQAProject.Pages.SauceDemo;
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
        public async Task Test002_FillStudentRegistrationForm()
        {
            RegistrationPage registrationPage = new RegistrationPage(Page);

            await registrationPage.GoToPage();

            StudentRegistrationBuilder builder = new StudentRegistrationBuilder();
            var studentData = builder.WithFirstName("Howard")
                .WithLastName("Wolowitz")
                .WithEmail("howard.wolowitz@magic.com")
                .WithGender(GenderType.Male)
                .WithMobile("8005553535")
                .WithDateOfBirth(new DateTime(1981, 12, 9))
                .WithSubjects("Maths", "Physics")
                .WithHobbies(HobbyType.Music, HobbyType.Sports)
                .WithPicture("resources/profilePic.jpeg")
                .WithAddress("123 Main St, Pasadena, CA")
                .WithLocation("NCR", "Delhi")
                .Build();
            await registrationPage.FillAllFormFieldAsync(studentData);
            await registrationPage.SubmitData();
            await registrationPage.CheckConfirmForm(studentData);
        }
    }
}
