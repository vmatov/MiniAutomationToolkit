using AQAProject.DataProvider;
using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.Components;

namespace AQAProject.Tests
{
    [TestFixture]
    public class EmailValidatorTests
    {
        [TestCaseSource(typeof(EmailTestDataProvider),
            nameof(EmailTestDataProvider.GetEmailCases))]
        public void EmailValidationTest(string email, bool result)
        {
            bool res = Validator.IsValid(email);
            Assert.That(res, Is.EqualTo(result),
                $"Емейл {email} не прошел валидацию, ожидалось {result}," +
                $" а на самом деле оказалось {res}");

        }
    }
}
