using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Webapi.Middleware{
    public class CustomTest : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("From custom middle ware ");
            await next(context);
            Console.WriteLine("From custom middle ware in return");
            
        }
    }
}