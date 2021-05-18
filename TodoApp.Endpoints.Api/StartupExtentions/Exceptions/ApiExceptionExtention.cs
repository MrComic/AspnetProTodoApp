using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class ApiExceptionExtention
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            var options = new ApiExceptionOptions();
            return builder.UseMiddleware<ApiExceptionMiddleware>(options);
        }

        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder,
            Action<ApiExceptionOptions> configureOptions)
        {
            var options = new ApiExceptionOptions();
            configureOptions(options);

            return builder.UseMiddleware<ApiExceptionMiddleware>(options);
        }
    }
}
