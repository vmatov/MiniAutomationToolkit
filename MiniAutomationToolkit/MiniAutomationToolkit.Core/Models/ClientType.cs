using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Models
{
    public class Client
    {
        public ClientType Type { get; set; }
        public int Amount { get; set; }
        public Client(int amount, ClientType type)
        {
            Amount = amount;
            Type = type;
        }
    }

    public enum ClientType
    {
        Regular = 5,
        Premium = 10,
        Vip = 15

    }
}
