using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using AQAProject.Methods;
using AQAProject.Preconditions;
using AQAProject.Interfaces.Dapper;
using AQAProject.Repositories;
using FluentAssertions;

namespace AQAProject.Tests
{
    internal class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test1_CheckAllUsers()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15); 
        }

        [Test]
        public async Task Test2_CheckUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(10);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test3_GetUserByFirstAndLastName()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByFirstAndLastName("Анна", "Соколова");
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test4_GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(7);
            address.Should().NotBeNull();
        }

        [Test]
        public async Task Test5_CheckAllCategories()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoriesAsync();
            categories.Should().HaveCount(6);
        }

        [Test]
        public async Task Test6_GetProductId()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductByIDAsync(2);
            product.Should().NotBeNull();
            product.categoryId.Should().Be(1);
            product.description.Should().Be("Флагманский смартфон Samsung");
            product.name.Should().Be("Samsung Galaxy S24");
            product.price.Should().Be(69990.0);
            product.stock.Should().Be(20);

        }

        [Test]
        public async Task Test7_GetOrderByID()
        {
            var orderRepo = p.Provider.GetService<IOrderRepository>();
            var orderItemRepo = p.Provider.GetService<IOrderItemRepository>();
            var order = await orderRepo.GetOrderByUserIDAsync(3);
            var itemList = await orderItemRepo.GetItemsByOrderIdAsync(order.id);
            itemList.Should().HaveCount(1);
            var productIds = itemList.Select(item => item.productId).ToList();
            productIds.Should().BeEquivalentTo(new[] { 4L });
        }


        //[Test]
        public async Task InitialiseTest()
        {
            var connectionString = "Data Source=marketplace.db";
            await using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            await DatabaseInitializer.InitializeAsync(connection);
        }
    }
}
