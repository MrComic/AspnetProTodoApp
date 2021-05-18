using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Contracts;
using TodoApp.Core.Domain.Todos.Data;
using Framework.Core.Domain.Data;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries.Contracts;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class AddDataAccessExtentsions
    {

        public static IServiceCollection AddDataAccess(
            this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services.AddRepositories(assembliesForSearch).AddUnitOfWorks(assembliesForSearch);

        public static IServiceCollection AddRepositories(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<>), typeof(IQueryRepository));

        public static IServiceCollection AddUnitOfWorks(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services.AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));
    }
}
