using AQAProject.DTO.UsersDTO;
using AQAProject.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;



namespace AQAProject.Tests
{
    public class RefitTests
    {
        private IUserApi api;

        [OneTimeSetUp]
        public void Status()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://reqres.in/api"));
            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IUserApi>();
        }

        [Test]
        public async Task TestOne()
        {
            var response = await api.GetUserAsync(2);
            Assert.That(response.Data.ID, Is.EqualTo(2));
        }

        [Test]
        public async Task TestTwo()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "Stannis",
                Job = "Baratheon Inc."
            };
            var response = await api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo(request.Name));
            Assert.That(response.Job, Is.EqualTo(request.Job));
        }

        [Test]
        public async Task TestThree()
        {
            var deleteResult = await api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}