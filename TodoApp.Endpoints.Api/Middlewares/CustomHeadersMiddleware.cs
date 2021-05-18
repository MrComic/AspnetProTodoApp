using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Endpoints.Api.Middlewares
{
    public class CustomHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomHeadersMiddleware(RequestDelegate next
            )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            await _next(context);
        }
    }
}
