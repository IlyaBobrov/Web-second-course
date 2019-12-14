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

using ASP_HW_3.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ASP_HW_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SmsMessageSender>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddTransient<MessageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IMessageSender messageSender, MessageService messageService)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            DefaultFilesOptions opt = new DefaultFilesOptions();
            opt.DefaultFileNames.Clear();
            opt.DefaultFileNames.Add("default.html");
            app.UseDefaultFiles(opt);

            app.UseStaticFiles();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<CheckTokenMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();

            app.Map("/main/tor", FuncTor);
            app.Map("/main/cube", FuncCube);
            //app.Map("/main/mes", FuncMes(app, messageSender));

            app.UseSession();
            app.Run(async (context) =>
            {
                IMessageSender messageSender = context.RequestServices.GetService<IMessageSender>();

                //context.Response.ContentType = "text/html;charset=utf-8";
                
                await context.Response.WriteAsync(
                    "You can go:\n" +
                    "/main/tor\n" +
                    "/main/cube\n\n" + messageSender.Send(context));
                await context.Response.WriteAsync($"{messageSender.Send(context)}");
            });
        }
        private static void FuncMes(IApplicationBuilder app, IMessageSender messageSender)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageSender.Send(context));
            });

        }

        private static void FuncTor(IApplicationBuilder app)
        {

            double R = 3,
                   rm = 1,
                   V = 0,
                   S = 0;

            app.Use(async (context, next) =>
            {
                await next.Invoke();
                await context.Response.WriteAsync($"Torus volume: {Math.Round(V, 2)}\n");
                await context.Response.WriteAsync($"Torus area: {Math.Round(S, 2)}\n");
            });

            app.Run(async (context) =>
            {
                V = 2 * Math.Pow(Math.PI, 2) * R * Math.Pow(rm, 2);
                S = 4 * Math.Pow(Math.PI, 2) * R * rm;
                await Task.FromResult(0);
            });
        }

        private static void FuncCube(IApplicationBuilder app)
        {
            double a = 2;
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Cube volume: {Math.Pow(a, 3)}\n");
                await context.Response.WriteAsync($"Cube area: {6 * a}\n");
            });
        }
        
    }
}