using AQAProject.Interfaces.Dapper;
using Dapper;
using AQAProject.Interfaces;
using AQAProject.DTO.DapperDTO;
using Microsoft.Data.Sqlite;

namespace AQAProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connection;
        
        public UserRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            using var db = new SqliteConnection(connection);
            var users = await db.QueryAsync<UserDTO>("SELECT * FROM Users");
            return users;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            using var db = new SqliteConnection(connection);
            var user = await db.QueryFirstOrDefaultAsync<UserDTO>("SELECT * FROM Users WHERE Id=@id", new {id});
            return user;
        }


        public async Task<UserDTO> GetUserByFirstAndLastName(string firstName, string lastName)
        {
            using var db = new SqliteConnection(connection);
            var user = await db.QueryFirstOrDefaultAsync<UserDTO>("SELECT * FROM Users WHERE FirstName=@firstName AND LastName=@lastName", new { firstName, lastName });
            return user;
        }
    }
}
