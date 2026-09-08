using AQAProject.Interfaces.Dapper;
using Dapper;
using AQAProject.Interfaces;
using AQAProject.DTO.DapperDTO;
using Microsoft.Data.Sqlite;

namespace AQAProject.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {

        private readonly string connection;

        public OrderItemRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetItemsByOrderIdAsync(long orderId)
        {
            using var db = new SqliteConnection(connection);
            var items = await db.QueryAsync<OrderItemsDTO>(
                "SELECT * FROM OrderItems WHERE OrderId = @OrderId",
                new { OrderId = orderId }
            );
            return items;
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByProductIdsAsync(IEnumerable<long> productIds)
        {
            using var db = new SqliteConnection(connection);
            var items = await db.QueryAsync<OrderItemsDTO>(
                "SELECT * from OrderItems WHERE ProductId IN @productIds",
                new { productIds });
            return items;
        }
    }
}
