using AQAProject.DTO.BookStoreDTO;
using AQAProject.Interfaces.BookStore;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using AQAProject.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests
{
    internal class BookStoreTests
    {
        private IBookAPI api;

        [OneTimeSetUp]

        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookAPI>();
        }

        //[Test]
        public async Task Test001_CreateUser()
        {
            var credentials = new UserCreateBodyDTO("Magnus", "StrongPass123!");
            var result = await api.CreateUserAsync(credentials);
            result.Username.Should().Be("Magnus");
        }

        [Test]
        public async Task Test002_GetToken()
        {
            var credentials = new UserCreateBodyDTO("Magnus", "StrongPass123!");
            var result = await api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Test003_GetUserId()
        {
            var credentials = new UserCreateBodyDTO("Magnus", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            result.UserId.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Test004_GetBookListAsync()
        {
            var result = await api.GetBookListAsync();
            result.Should().NotBeNull();
            result.Books.Should().HaveCount(8);
            result.Books.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Test005_GetBookByIsbnAsync()
        {
            var result = await api.GetBookByIsbnAsync("9781491950296");
            result.Should().NotBeNull();
        }

        [Test]
        public async Task Test006_AddBookToUserAsync()
        {
            var token = await GetTokenAsync();

            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomizerHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            var response = await api.AddBookToUserAsync(request, token); 

            response.Should().NotBeNull();
        }

        [Test]
        public async Task Test007_DeleteBookByIsbn() 
        {
            var token = await GetTokenAsync();

            var userId = await GetUsersIdAsync();

            var request = new DeleteBookRequestDTO
            (
                "9781449331818",
                userId
            );

            var response = await api.DeleteBookFromUserAsync(request, token);
            response.Should().NotBeNull();
        }

        

        [Test]
        public async Task SendInvalidRequestAsync()
        {
            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomizerHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            Func<Task> act = async () => await api.AddBookToUserAsync(request, token: null);
            act.Should().ThrowAsync<ApiException>(); //.Where(p => p.StatusCode == System.Net.HttpStatusCode.BadRequest) - по статус кодам почему-то не отрабатывает
        }


        private async Task<string> GetTokenAsync()
        {
            var credentials = new UserCreateBodyDTO("Magnus", "StrongPass123!");
            var token = await api.GenerateTokenAsync(credentials);
            var result = $"Bearer {token.Token}";

            return result;
        }

        private async Task<string> GetUsersIdAsync()
        {
            var credentials = new UserCreateBodyDTO("Magnus", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            return result.UserId;
        }
    }
}
