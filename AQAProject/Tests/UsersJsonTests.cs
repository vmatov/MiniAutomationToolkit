using AQAProject.DTO.UserDataDTO;
using AQAProject.Methods;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AQAProject.Tests
{
    internal class UsersJsonTests
    {
        private UserDTO user;

        [OneTimeSetUp]
        public void SetUp()
        {
            user = FileReader.ReadFile<UserDTO>("UsersData.json");
        }

        [Test]
        public void TestOne_UserCount()
        {
            var userCount = user.data.Count;
            userCount.Should().Be(10);
        }

        [Test]
        public void TestTwo_CheckFirstUser()
        {
            user.data[0].profile.fullName.Should().Be("Alice Johnson");
        }

        [Test]
        public void TestThree_CheckUniqueIds()
        {
            var ids = user.data.Select(u => u.id).Distinct().ToList();
            ids.Should().HaveCount(10);
        }

        [Test]
        public void TestFour_CheckPremiumUsers()
        {
            var premiumUsers = user.data.Where(u => u.profile.tags.Contains("premium")).ToList();
            premiumUsers.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void TestFive_CheckCitiesNullable()
        {
            var cities = user.data.Select(u => u.profile.address.city).Where(c => c == null || c == "").ToList();
            cities.Should().HaveCount(0);
        }

        [Test]
        public void TestSix_CheckStockholm()
        {
            var stockResidents = user.data.Select(u => u.profile.address.city).Where(c => c == "Stockholm").ToList();
            stockResidents.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void TestSeven_CheckAges()
        {
            var ages = user.data.Select(u => u.profile.age).Where(a => a > 60 && a < 18).ToList();
            ages.Should().HaveCount(0);
        }

        [Test]
        public void TestEight_CheckAdminUsers()
        {
            var adminUsers = user.data.Where(u => u.roles.Contains("admin")).ToList();
            adminUsers.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void TestNine_CheckSwedenCoordinates()
        {
            // Проверяем принадлежность координат относительно крайних точек Швеции - всё что за пределами в список не попадает
            // Был вариант проверять, отправляя координаты каждого города в геокодер, но там ограничение по запросу в секунду
            var geoCities = user.data.Select(u => u.profile.address.geo).Where(c => c.lat > 69.06 && c.lat < 55.34 && c.lng > 24.15 && c.lng < 11.00).ToList();
            geoCities.Should().BeEmpty();
        }

        [Test]
        public void TestTen_CheckStreetNames()
        {
            string pattern = @"^[a-zA-Zа-яА-Я](?=.*\d)";
            var streets = user.data.Select(u => u.profile.address.street).Where(s => !Regex.IsMatch(s, pattern)).ToList();
            streets.Should().HaveCount(0);
        }
    }
}
