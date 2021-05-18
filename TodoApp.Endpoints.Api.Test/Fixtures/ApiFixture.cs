using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;
using TodoApp.Endpoints.Api.Test.ExtentionMethods;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TodoApp.Endpoints.Api.Test.Fixtures
{
    public class ApiFixture : WebApplicationFactory<Api.Startup>
    {
        public static void InsertFakeData(TodoDbContext context, int count)
        {
            for (int i = 0; i <= count; i++)
            {
                context.Todos.Add(
                    new TodoApp.Core.Domain.Todos.Entities.Todo("test" + i, "test" + i, DateTime.Now.AddDays(i + 1)));
            }
            context.SaveChanges();
        }

        public static void InsertFakeData(QueryDbContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Todos.Add(
                    new Infra.Data.SqlServer.Queries.Todo.Entities.Todo()
                    {
                        Text = "test" + i,
                        Title = "test" + i,
                        ValidTo = DateTime.Now.AddDays(i + 1)
                    });
            }
            context.SaveChanges();
        }


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<TodoDbContext>();

                var commandDbContext = services.SingleOrDefault( d => d.ServiceType == typeof(DbContextOptions<TodoDbContext>));
                var queryDbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<QueryDbContext>));
                services.Remove(queryDbContext);
                services.Remove(commandDbContext);

                //services.RemoveAll<QueryDbContext>();
                services
            .AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("testcommand"),ServiceLifetime.Transient);

                services
                   .AddDbContext<QueryDbContext>(options => options.UseInMemoryDatabase("testquery"), ServiceLifetime.Transient);


                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TodoDbContext>();
                    var db1 = scopedServices.GetRequiredService<QueryDbContext>();

                    InsertFakeData(db,10);
                    InsertFakeData(db1, 10);
                }
               // services.BuildServiceProvider();
            });
        }
    }
}
