using AQAProject.DTO.UserDataDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace AQAProject.Methods
{
    internal class FileReader
    {
        public static T ReadFile<T>(string fileName)
        {
            // Указываем дефолтный путь к папке resources, потому что там мы храним наши json файлы
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "resources", fileName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);

        }
    }
}
