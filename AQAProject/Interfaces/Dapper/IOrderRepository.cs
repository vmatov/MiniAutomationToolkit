using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.DTO.DapperDTO;
using Tests1.DTO.DapperTestsDTO;

namespace AQAProject.Interfaces.Dapper
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByUserIDAsync(int userId);
        Task<IEnumerable<OrderDTO>> GetOrdersByIDAsync(IEnumerable<long> ids);
    }
}
