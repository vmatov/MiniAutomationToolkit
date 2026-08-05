using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Models
{
    public class LongOperationSimulator
    {

public string LongOperation()
        {
            // Симуляция долгой операции
            Thread.Sleep(2000); // Задержка 2 секунды
            return "Done";
        }

public async Task<string> LongOperationAsync()
        {
            // Симуляция долгой операции
            await Task.Delay(2000); // Задержка 2 секунды
            return "Done";
        }

    }

   
}
