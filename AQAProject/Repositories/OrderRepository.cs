using AQAProject.Interfaces.Dapper;
using Dapper;
using AQAProject.Interfaces;
using AQAProject.DTO.DapperDTO;
using Microsoft.Data.Sqlite;

namespace AQAProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly string connection;

        public OrderRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<OrderDTO> GetOrderByUserIDAsync(int userId)
        {
            using var db = new SqliteConnection(connection);
            var order = await db.QueryFirstOrDefaultAsync<OrderDTO>(
                "SELECT * FROM Orders WHERE UserId = @UserId",
                new { UserId = userId }
            );
            return order;
        }
    }
}
