using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Runtime.CompilerServices;
using AQAProject.Interfaces.Dapper;
using AQAProject.Repositories;

namespace AQAProject.Modules
{
    public static class DataAccessMarketplaceModule
    {
        public static IServiceCollection AddDataMarketplaceAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository>(provider => new UserRepository(connectionString));
            services.AddScoped<IAddressRepository>(provider => new AddressRepository(connectionString));
            services.AddScoped<ICategoryRepository>(provider => new CategoryRepository(connectionString));
            services.AddScoped<IProductRepository>(provider => new ProductRepository(connectionString));
            services.AddScoped<IOrderRepository>(provider => new OrderRepository(connectionString));
            services.AddScoped<IOrderItemRepository>(provider => new OrderItemRepository(connectionString));
            return services;
        }
    }
}
