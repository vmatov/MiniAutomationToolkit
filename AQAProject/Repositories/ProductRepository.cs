using AQAProject.Interfaces.Dapper;
using Dapper;
using AQAProject.Interfaces;
using AQAProject.DTO.DapperDTO;
using Microsoft.Data.Sqlite;

namespace AQAProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;

        public ProductRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<ProductDTO> GetProductByIDAsync(int id)
        {
            using var db = new SqliteConnection(connection);
            var product = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * FROM Products WHERE Id=@id", new { id });
            return product;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int id)
        {
            using var db = new SqliteConnection(connection);
            var products = await db.QueryAsync<ProductDTO>("SELECT * FROM Products WHERE CategoryId=@id", new { id });
            return products;
        }
    }
}
