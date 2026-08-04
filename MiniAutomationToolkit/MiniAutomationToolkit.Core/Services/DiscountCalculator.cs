using MiniAutomationToolkit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAutomationToolkit.Core.Services
{
    public static class DiscountCalculator
    {
        public static decimal CalculateDiscount(
            decimal orderAmount,
            ClientType clientType)
        {
            if (orderAmount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderAmount), orderAmount, "Order amount cannot be negative");
            }

            switch (clientType)
            {
                case ClientType.Vip:
                    return orderAmount * 0.15m;
                case ClientType.Premium:
                    if (orderAmount > 1000)
                    {
                        return orderAmount * 0.10m;
                    }
                    return orderAmount * 0.05m;
                case ClientType.Regular:
                    if (orderAmount > 1000)
                    {
                        return orderAmount * 0.05m;
                    }
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
