using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication13
{
    public class Startup
    {
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMiddleware<ErrorHandlingMiddleWare>();
            app.UseMiddleware<AuthenticationMiddleWare>();
            app.UseMyRoute();
            
            app.Run(async(context)=> 
            {
                await context.Response.WriteAsync("Hello Husia");
            });
        }

        
    }
    public static class RoutingExtension
    {
        public static IApplicationBuilder UseMyRoute(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleWare>();
        }
    }
}
