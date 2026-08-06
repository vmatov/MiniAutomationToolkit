using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Models
{
    public class Guard
    {

public static void EnsurePositive(
    int number,
    string parameterName = "number")


        {
            if (number <= 0)
            {
                throw new ValidationException($"Validation failed: {parameterName} must be positive. Value: {number}");
            }
        }
    }
   
}
