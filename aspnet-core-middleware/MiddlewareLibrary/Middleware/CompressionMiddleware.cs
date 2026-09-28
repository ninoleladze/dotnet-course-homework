using System;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareLibrary.Middleware;

/// <summary>
/// Middleware that compresses responses based on the client's accepted encodings.
/// </summary>
public class CompressionMiddleware(RequestDelegate next, ILogger<CompressionMiddleware> logger)
{
    /// <summary>
    /// Compresses the response stream when the client supports compression and forwards the request to the next middleware.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        try
        {
            var acceptEncoding = context.Request.Headers["Accept-Encoding"].ToString();

            if (acceptEncoding.Contains("gzip", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.Headers["Content-Encoding"] = "gzip";
                context.Response.Body = new GZipStream(originalBodyStream, CompressionLevel.Fastest, leaveOpen: true);
            }
            else if (acceptEncoding.Contains("deflate", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.Headers["Content-Encoding"] = "deflate";
                context.Response.Body = new DeflateStream(originalBodyStream, CompressionLevel.Fastest, leaveOpen: true);
            }

            await next(context);
        }
        finally
        {
            if (context.Response.Body is GZipStream or DeflateStream)
            {
                await context.Response.Body.DisposeAsync();
                context.Response.Body = originalBodyStream;
                logger.LogDebug("Response stream compressed for {Path}", context.Request.Path);
            }
        }
    }
}

