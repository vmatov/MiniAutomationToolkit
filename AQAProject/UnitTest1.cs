using System.Net.Http.Json;
using System.Text.Json;
using NUnit.Framework;

namespace AQAProject
{
    public class Tests
    {

        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {

            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I3Q38F2JDCzaphi3n13THU5zc4");

        }

        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;
        }

        [Test]
        public async Task Test3()
        {
            var createUserRequest = new CreateUserRequestDTO
            {
                Name = "Stannis",
                Job = "Baratheon Inc."
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", createUserRequest);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO userResponse = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
        }

        [Test]
        public async Task Test4()
        {
            var createUserRequest = new CreateUserRequestDTO
            {
                Name = "Stannis",
                Job = "One true king"
            };

            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", createUserRequest);
            response.EnsureSuccessStatusCode();

        }

        [Test]
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");
            response.EnsureSuccessStatusCode();

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
