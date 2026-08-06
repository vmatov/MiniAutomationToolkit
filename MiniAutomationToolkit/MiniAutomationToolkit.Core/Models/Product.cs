using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Models
{
    public record Product
    {
       public string Name { get; init; }
       public decimal Price { get; init; }
       public string Category { get; init; }

    }
}
