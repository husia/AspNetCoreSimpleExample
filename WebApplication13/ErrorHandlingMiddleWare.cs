using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
namespace WebApplication13
{
    public class ErrorHandlingMiddleWare
    {
        RequestDelegate _next;
        public ErrorHandlingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Access Denied");
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Not Found");
        }
    }
}
