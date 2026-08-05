using MiniAutomationToolkit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Services
{
    public class ErrorLogger
    {
        public string? TryReadFile(
    string sourceFilePath,
    string logFilePath)
        {
            try
            {
                string content = File.ReadAllText(sourceFilePath);
                return content;
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "FileNotFoundException" || ex.GetType().Name == "UnauthorizedAccessException")
                {
                    var errorMessage = $"{DateTime.Now} | {ex.GetType().Name} | {ex.Message}{Environment.NewLine}";
                    File.AppendAllText(logFilePath, errorMessage);
                    Console.WriteLine(File.ReadAllText(logFilePath));
                }
                else
                {
                    throw;
                }
                return null;
            }
        }

    }
}
