using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AQAProject.Modules;

namespace AQAProject.Preconditions
{
    internal class DataBasePreconditions
    {
        public ServiceProvider Provider { get; private set; }

        public DataBasePreconditions()
        {
            var services = new ServiceCollection();
            services.AddDataMarketplaceAccess("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}
