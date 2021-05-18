using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Infra.Data.SqlServer.Todos;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class RepositoriesConfigurationExtention
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            return services;
        }
    }
}
