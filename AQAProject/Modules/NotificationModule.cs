using AQAProject.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Modules
{
    public static class NotificationModule
    {

        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<EmailSender>();
            services.AddScoped<UserNotifier>();
            return services;
        }
    }
}
