using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DataProvider
{
    public static class EmailProvider
    {
        private const string LoginDataFilePath = @"resources\SauceDemoLogins.csv";

        public static IEnumerable<TestCaseData> GetLoginCases()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string fullPath = Path.Combine(baseDirectory, LoginDataFilePath);
            var lines = File.ReadAllLines(fullPath);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');
                string login = parts[0];
                string password = parts[1];
                yield return new TestCaseData(login, password); //именно так оформляем возврат тестовых случаев
            }
        }
    }
}
