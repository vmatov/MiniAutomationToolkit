using AQAProject.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Tests
{
    [TestFixture]
    public class CalculatorTests
    {

        [TestCase(1, 2, 3)]
        [TestCase(-2, -6, -8)]
        [TestCase(-5, 10, 5)]
        public void AddCalculatorTest(int a, int b, int result)
        {
            int res = Calculator.Add(a, b);
            Assert.That(res, Is.EqualTo(result),
                $"Expected {result} but was {res}, a = {a}, b = {b}");
        }
    }
}
