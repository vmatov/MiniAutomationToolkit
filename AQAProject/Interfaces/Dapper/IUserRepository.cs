using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.DTO.DapperDTO;

namespace AQAProject.Interfaces.Dapper
{
    public interface IUserRepository
    {

        Task<IEnumerable<UserDTO>> GetUsersAsync();

        Task<UserDTO> GetUserByIdAsync(int id);

        Task<UserDTO> GetUserByFirstAndLastName(string firstName, string lastName);


    }
}
