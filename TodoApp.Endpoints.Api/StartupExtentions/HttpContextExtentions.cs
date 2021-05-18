using Framework.Core.Domain.ApplicationServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Endpoints.Api.StartupExtentions
{
    public static class HttpContextExtentions
    {
        public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
            (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

        public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
            (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));
    }
}
