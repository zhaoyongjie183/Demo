using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
       
        public static IApplicationBuilder UseExceptionHandlerMiddlewareExtensions(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(x=> {

                x.Use(async (context, next) => {

                    context.Response.StatusCode = 500;

                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(

                      new { IsSuccess = false, OperationDesc = "请求错误" }
                    ));

                    await next();
                });
                
            });
        }
    }
}
