using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Handler Before next invoke");

                if (context.Request.Path != "/test")
                {
                    await next();
                    await context.Response.WriteAsync("Handler after next invoke");
                }
                else
                {
                    await context.Response.WriteAsync("---test---");
                }
            });

            app.Run(async (context) => { await context.Response.WriteAsync("-----Run Handler-----"); });


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Handler before next invoke");

            //    await next();

            //    await context.Response.WriteAsync("Handler before next invoke");
            //});

        }
    }
}
