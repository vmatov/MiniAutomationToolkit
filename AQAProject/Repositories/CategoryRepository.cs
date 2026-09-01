using AQAProject.DTO.DapperDTO;
using AQAProject.Interfaces;
using AQAProject.Interfaces.Dapper;
using Dapper;
using Microsoft.Data.Sqlite;
using Tests1.DTO.DapperTestsDTO;


namespace AQAProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connection;

        public CategoryRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            using var db = new SqliteConnection(connection);
            var categories = await db.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
            return categories;
        }
    }
}
