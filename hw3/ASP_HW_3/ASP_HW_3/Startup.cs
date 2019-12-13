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
//using static ASP_HW_3.wwwroot.Setvices.IMessageSender;

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
            //services.AddRazorPages();
            //services.AddTransient<IMessageSender, EmailMessageSender>();
        }

        /*
        public void Configure(IApplicationBuilder app, IMessageSender sender)
        {
            app.Run(async (context) =>
            {
                IMessageSender sender = context.RequestServices.GetService<IMessageServices>();
                await context.Response.WriteAsync(sender.Send());
            });
        }
        */
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            DefaultFilesOptions opt = new DefaultFilesOptions();
            opt.DefaultFileNames.Clear();
            opt.DefaultFileNames.Add("default.html");
            app.UseDefaultFiles(opt);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<CheckTokenMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();

            ///Task 1,2,
            app.Map("/main/tor", FuncTor);
            app.Map("/main/cube", FuncCube);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "You can go:\n" +
                    "/main/tor\n" +
                    "/main/cube");
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