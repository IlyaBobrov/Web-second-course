using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;


namespace ASP_HW_3
{
    public class CheckTokenMiddleware
    {
        
            private readonly RequestDelegate _next;

            public CheckTokenMiddleware(RequestDelegate next)
            {
                this._next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var token = context.Request.Query["token"];
                if (token != "1"/* || token != "2"*/)
                {
                //context.Response.StatusCode = 403;
                await context.Response.WriteAsync("token does not exist");

            }
            else
                {
                    await _next.Invoke(context);
                }
            }
        
        

    }
}
