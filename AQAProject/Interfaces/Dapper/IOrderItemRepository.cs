using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.DTO.DapperDTO;
using Tests1.DTO.DapperTestsDTO;

namespace AQAProject.Interfaces.Dapper
{
    public interface IOrderItemRepository
    {

        Task<IEnumerable<OrderItemsDTO>> GetItemsByOrderIdAsync(long orderId);
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByProductIdsAsync(IEnumerable<long> productIds);
    }
}
