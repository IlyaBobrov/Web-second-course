using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP_HW_3
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/index" || path == "/")
            {
                await context.Response.WriteAsync("Index Page");
            }else if (path == "/hello")
            {
                await context.Response.WriteAsync("Hello World!");
            }
            else if (path == "/main")
            {
                await _next.Invoke(context);
            }
            else if (path == "/main/tor")
            {
                await _next.Invoke(context);
            }
            else if (path == "/main/cube")
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 404;
            }
            //await _next.Invoke(context);
        }
    }
}
