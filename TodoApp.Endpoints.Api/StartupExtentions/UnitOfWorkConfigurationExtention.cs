using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Domain.Data;
using TodoApp.Infra.Data.SqlServer;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class UnitOfWorkConfigurationExtention
    {
        public static IServiceCollection ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,TodosUnitOfWork>();
            return services;
        }
    }
}
