using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Webapi.Entities;

namespace Webapi.Middleware{
    public class CustomExceptionMiddleware{
        public readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next){
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context){
            try{
                await _next(context);
            }catch(Exception){
                await HandlerExceptionAsync(context);
            }
        }
        public Task HandlerExceptionAsync(HttpContext context){
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails(){
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error"
            }.ToString());
        }
    }
}