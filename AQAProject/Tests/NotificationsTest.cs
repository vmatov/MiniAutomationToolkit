using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.Preconditions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace AQAProject.Tests
{
    internal class NotificationsTest
    {
        private readonly NotificationPreconditions p = new NotificationPreconditions();

        [Test]
        public void TestUserNotifier()
        {
            var notifier = p.Provider.GetService<DependencyInjection.UserNotifier>();
            notifier.Should().NotBeNull("UserNotifier service should not be null");
            notifier.Notify(1);
        }
    }
}
