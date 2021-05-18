using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class DatabaseContextsConfigurationExtentions
    {
        public static IServiceCollection ConfigureDatabases(this IServiceCollection services,
           IConfiguration configuration)
        {
            services
                .AddDbContext<TodoDbContext>(c =>
                            c.UseSqlServer(configuration.GetConnectionString("dbcontextcnn")));
            services
    .AddDbContext<QueryDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("dbcontextcnn")));
            return services;
        }
    }
}
