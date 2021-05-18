using Framework.Core.Domain.ApplicationServices;
using Framework.Core.Domain.Queries;
using Framework.Domain.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class AddApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services
                .AddCommandHandlers(assembliesForSearch)
                .AddCommandDispatcherDecorators()
                .AddQueryHandlers(assembliesForSearch);

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>),
                typeof(ICommandHandler<,>));

        private static IServiceCollection AddCommandDispatcherDecorators(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            return services;
        }

        private static IServiceCollection AddQueryHandlers(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch) =>
            services.AddWithTransientLifetime(assembliesForSearch, typeof(IQueryHandler<,>), typeof(IQueryDispatcher));
    }
}
