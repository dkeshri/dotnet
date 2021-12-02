using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Webapi.Entities;

namespace Webapi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {

                
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(option =>
                {
                    option.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                context.Response.ContentType = "application/json";
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if(ex!=null){
                                    await context.Response.WriteAsync(new ErrorDetails(){
                                        StatusCode = (int)HttpStatusCode.InternalServerError,
                                        Message = "Internal Server Error"
                                    }.ToString());
                                }

                            }

                    );
                });
            }
        }
    }
}