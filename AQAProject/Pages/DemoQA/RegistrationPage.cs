using AQAProject.Storages.ForUI.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AQAProject.Pages.DemoQA
{
    public class RegistrationPage
    {
        public RegistrationPage(IPage page)
        {
            Page = page;
        }
        private string url = "https://demoqa.com/automation-practice-form";

        private readonly IPage Page;
        private ILocator FirstNameInput => Page.Locator("[id='firstName']");
        private ILocator LastNameInput => Page.Locator("[id='lastName']");
        private ILocator EmailInput => Page.Locator("[id='userEmail']");
        private ILocator CheckBlock => Page.Locator("[class='form-check form-check-inline']");
        private ILocator MobileNumberInput => Page.Locator("[id='userNumber']");
        private ILocator DateOfBirthInput => Page.Locator("[id='dateOfBirthInput']");
        private ILocator DataPickerSelectMonth => Page.Locator("[class='react-datepicker__month-select']");
        private ILocator DataPickerMonth => Page.Locator("[class='react-datepicker__month']");
        private ILocator DataPickerSelectYear => Page.Locator("[class='react-datepicker__year-select']");
        private ILocator SubjectsInput => Page.Locator("[id='subjectsInput']");
        private ILocator SubjectDropdown => Page.Locator("[id='react-select-2-listbox']");
        private ILocator UploadPictureInput => Page.Locator("[id='uploadPicture']");
        private ILocator CurrentAddressInput => Page.Locator("[id='currentAddress']");
        private ILocator StateInput => Page.Locator("[id='react-select-3-input']");
        private ILocator StateDropdown => Page.Locator("[id='react-select-3-listbox']");
        private ILocator CityInput => Page.Locator("[id='react-select-4-input']");
        private ILocator CityDropdown => Page.Locator("[id='react-select-4-listbox']");
        private ILocator SubmitButton => Page.Locator("[id='submit']");
        private ILocator ConfirmModal => Page.Locator("[class='modal-content']");

        public async Task GoToPage()
        {
            await Page.GotoAsync(url);
        }

        public async Task SubmitData()
        {
            await SubmitButton.ClickAsync();
        }

        public async Task FillAllFormFieldAsync(StudentRegistrationFormModel studentData)
        {
            if (!string.IsNullOrEmpty(studentData.FirstName))
            {
                await FirstNameInput.FillAsync(studentData.FirstName);
            }
            if (!string.IsNullOrEmpty(studentData.LastName))
            {
                await LastNameInput.FillAsync(studentData.LastName);
            }
            if (!string.IsNullOrEmpty(studentData.Email))
            {
                await EmailInput.FillAsync(studentData.Email);
            }
            if (studentData.Gender is Enums.GenderType gender)
            {
                await CheckBlock.Locator($"[value='{gender}']").CheckAsync();
            }
            if (!string.IsNullOrEmpty(studentData.MobileNumber))
            {
                await MobileNumberInput.FillAsync(studentData.MobileNumber);
            }
            if (studentData.Hobbies != null && studentData.Hobbies.Any())
            {
                foreach (var hobby in studentData.Hobbies)
                {
                    await ChooseHobby(hobby);
                }
            }
            if (studentData.DateOfBirth != default)
            {
                await DataPick(studentData.DateOfBirth);
            }
            if (studentData.Subjects != null && studentData.Subjects.Any())
            {
                foreach (var subject in studentData.Subjects)
                {
                    await ChooseSubject(subject);
                }
            }
            if (!string.IsNullOrEmpty(studentData.PicturePath))
            {
                await UploadPictureInput.SetInputFilesAsync(studentData.PicturePath);
            }
            if (!string.IsNullOrEmpty(studentData.CurrentAddress))
            {
                await CurrentAddressInput.FillAsync(studentData.CurrentAddress);
            }
            if (!string.IsNullOrEmpty(studentData.State))
            {
                await StateInput.ClickAsync();
                await StateDropdown.Locator($"text={studentData.State}").ClickAsync();
            }
            if (!string.IsNullOrEmpty(studentData.City))
            {
                await CityInput.ClickAsync();
                await CityDropdown.Locator($"text={studentData.City}").ClickAsync();
            }
        }

        public async Task DataPick(DateTime date)
        {
            await DateOfBirthInput.ClickAsync();
            await DateOfBirthInput.FillAsync(date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
        }

        public async Task ChooseSubject(string subject)
        {
            await SubjectsInput.FillAsync(subject);
            await SubjectDropdown.Locator($"text={subject}").ClickAsync();
        }

        public async Task ChooseHobby(Enums.HobbyType hobby)
        {
            var Hobby = CheckBlock.Filter(new() { HasText = $"{hobby}" });
            await Hobby.Locator("[type='checkbox']").CheckAsync();

        }

        public async Task CheckConfirmForm(StudentRegistrationFormModel studentData)
        {
            var expectedData = new Dictionary<string, string?>
    {
        { "Student Name", $"{studentData.FirstName} {studentData.LastName}".Trim() },
        { "Student Email", studentData.Email },
        { "Gender", $"{studentData.Gender}" },
        { "Mobile", studentData.MobileNumber },
        { "Date of Birth", studentData.DateOfBirth.ToString("dd MMMM,yyyy", CultureInfo.InvariantCulture)},
        { "Subjects", studentData.Subjects != null ? string.Join(", ", studentData.Subjects) : null },
        { "Hobbies", studentData.Hobbies != null ? string.Join(", ", studentData.Hobbies) : null },
        { "Picture", Path.GetFileName(studentData.PicturePath) },
        { "Address", studentData.CurrentAddress },
        {"State and City", $"{studentData.State} {studentData.City}".Trim()}
    };
            foreach (var (label, expectedValue) in expectedData)
            {
                if (string.IsNullOrWhiteSpace(expectedValue)) continue;
                var row = ConfirmModal.Locator("tr").Filter(new() { HasText = label });
                await Assertions.Expect(row.Locator("td").Nth(1)).ToHaveTextAsync(expectedValue);
            }
        }
    }
}
