using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoApp.Endpoints.Api.StartupExtentions;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;

namespace TodoApp.Core.ApplicationServices.Test.Fixtures
{
    public class ServiceInjectionFixture
    {
        public ServiceInjectionFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()),
                    ServiceLifetime.Transient);

            serviceCollection
               .AddDbContext<QueryDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()),
                   ServiceLifetime.Transient);

            serviceCollection.AddDependencies("Todo");
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
