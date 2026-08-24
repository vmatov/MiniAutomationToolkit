using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using AQAProject.DTO.OrderDataDTO;
using System.Text.Json;

namespace AQAProject.Tests
{
    public class OrderJsonTests
    {
        private OrderDTO order;
        [OneTimeSetUp] 
        public void SetUp() 
        {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "resources", "OrderData.json");
        string json = File.ReadAllText(path);

        order = JsonSerializer.Deserialize<OrderDTO>(json);
        }

        [Test]
        public void TestOne_CheckItemsIsNotNull()
        {
            foreach (var item in order.Items)
            {
               TestContext.WriteLine(item.Name);
            }
            order.Items.Should().NotBeNull();
            order.Items.Should().HaveCount(3);
        }

        [Test]
        public void TestTwo_CheckItemsSum()
        {
            //decimal sum = 0m;
            var sum = order.Items.Sum(item => item.Price * item.Quantity);
            sum.Should().Be(order.Summary.ItemsTotal);
        }

        [Test]
        public void TestThree_CheckElectronics()
        {
            var electronicsItems = order.Items.Where(item => item.Category == "Electronics").ToList();
            using (new AssertionScope())
            {
                electronicsItems.Should().OnlyContain(item => item.Category == "Electronics");
                electronicsItems.Should().HaveCount(2);
            }
        }
    }
}
