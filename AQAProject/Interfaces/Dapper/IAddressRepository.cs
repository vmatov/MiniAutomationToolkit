using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.DTO.DapperDTO;

namespace AQAProject.Interfaces.Dapper
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId(int userId);
    }

}
