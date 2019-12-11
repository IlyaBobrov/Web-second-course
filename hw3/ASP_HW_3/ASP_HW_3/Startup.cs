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
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            
            ///Task 1,2
            /*
           
            */

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            
            app.Map("/index", Index);
            app.Map("/about", About);
            app.Map("/tor", FuncTor);
            app.Map("/cube", FuncCube);


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Page Not Found\n" +
                    "You can go:\n" +
                    "/index\n" +
                    "/about\n" +
                    "/tor\n" +
                    "/cube");
             });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
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
                await context.Response.WriteAsync("Hello World!\n\n");

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

        /*
        ///Task 1
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!\n");
            });
        });

        //app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
        */

    }
}
