using AQAProject.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AQAProject.Hooks;
using Microsoft.Playwright;

namespace AQAProject.Tests.GroupTests
{
    [TestFixture]
    public class Group1Tests : HooksForGroupTests1
    {
        [Test]
        [Parallelizable]
        [Description("")] //описание теста
        [Repeat(10)] //запустить тест 10 раз, один из 10 упал - красный весь тест
        public void Test11_ID12345()
        {
            Assert.That(true);
        }

        [Test]
        [Category("QA")]
        [Category("Fake")]
        [Timeout(30000)] //если тест не уложится в лимит, он будет отмечен красным (но он завершится!)
        public void Test12()
        {
            Assert.That(true);
        }

        [Test]
        [Ignore("reason")]
        [Order(1)]
        [Retry(2)] //перезапустить тест после падения
        public void Test13()
        {
            Assert.That(true);
        }
    }
}
