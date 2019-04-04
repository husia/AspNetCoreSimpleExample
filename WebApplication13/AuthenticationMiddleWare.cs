using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
namespace WebApplication13
{
    public class AuthenticationMiddleWare
    {
        RequestDelegate _next;
        public AuthenticationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (String.IsNullOrEmpty(token))
                context.Response.StatusCode = 403;
            else
                await _next(context);
        }
    }
}
