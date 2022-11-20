using System.Net;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Middleware
{
    /// <summary>
    /// Global Exception handling
    /// </summary>
    public static class ExceptionExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogManager logger)
        {
            
            app.UseExceptionHandler(appError => 
                { 
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

                        context.Response.ContentType = "application/json"; 

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (contextFeature != null)
                        {
                            logger.Error($"Something went wrong: {contextFeature.Error}"); 
                            
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode, Message = "Internal Server Error."
                            }.ToString());
                        }
                    });
                });
        }
    }
}
