using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Webapi.Entities;
using Microsoft.Extensions.Hosting;
namespace Webapi.Middleware
{
    public class CustomExceptionMiddleware : IMiddleware
    {
        private IWebHostEnvironment env;
        public CustomExceptionMiddleware(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!env.IsDevelopment())
            {
                try
                {
                    await next(context);
                }
                catch (Exception)
                {
                    await HandlerExceptionAsync(context);
                }
            }else{
                await next(context);
            }

        }
        public Task HandlerExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error"
            }.ToString());
        }


    }
}