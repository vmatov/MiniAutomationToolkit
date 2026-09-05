using AQAProject.DTO.DapperDTO;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;

namespace AQAProject.Interfaces.Dapper
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductByIDAsync(int id);

    }
}
