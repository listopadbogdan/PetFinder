using System.Net;
using System.Net.Mime;
using PetFinder.API.Response;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.API.Middlewares;

public class ExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
            
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            Error error = Error.Failure("internal.server", ex.Message);
            var result = Envelope.Error(error);
            
            await context.Response.WriteAsJsonAsync(result);
        }
    }
    
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
} 
