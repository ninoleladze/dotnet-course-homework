using System;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareLibrary.Middleware;

/// <summary>
/// Middleware that captures unhandled exceptions and returns standardized error responses.
/// </summary>
public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    /// <summary>
    /// Wraps the request processing in a try/catch block and handles exceptions using a standardized JSON response.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing request {Path}", context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = exception switch
        {
            ArgumentNullException => 400,
            UnauthorizedAccessException => 401,
            NotImplementedException => 501,
            _ => 500,
        };
        context.Response.ContentType = MediaTypeNames.Application.Json;

        var response = new
        {
            error = exception.GetType().Name,
            message = exception.Message,
            statusCode = context.Response.StatusCode,
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}

