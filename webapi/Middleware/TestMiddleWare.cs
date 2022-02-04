using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace Webapi.Middleware
{
    public class TestMiddleware : IMiddleware
    {
        private IWebHostEnvironment env;
        public TestMiddleware(IWebHostEnvironment env)
        {
           // this.app = app;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context); // next is use to go to the next middle ware and we will wait till 
            // all the middleWare execute and return back to this method again 
            // after that below line will execute.
            // Console.Write("From TestMiddle ware");
        }
    }
}