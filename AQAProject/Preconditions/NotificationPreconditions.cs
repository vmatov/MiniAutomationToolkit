using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.Modules;

namespace AQAProject.Preconditions
{
    internal class NotificationPreconditions
    {
        public ServiceProvider Provider { get;}

        public NotificationPreconditions()
        {
            var services = new ServiceCollection();
            services.AddNotifications();
            Provider = services.BuildServiceProvider();
        }
    }
}
