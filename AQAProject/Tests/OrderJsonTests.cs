using AQAProject.DTO.OrderDataDTO;
using AQAProject.Methods;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AQAProject.Tests
{
    public class OrderJsonTests
    {
        private OrderDTO order;

        [OneTimeSetUp] 
        public void SetUp() 
        {
            order = FileReader.ReadFile<OrderDTO>("OrderData.json");

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
