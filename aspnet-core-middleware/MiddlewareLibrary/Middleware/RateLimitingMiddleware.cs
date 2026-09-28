using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareLibrary.Middleware;

/// <summary>
/// Middleware that enforces request rate limits based on client IP address.
/// </summary>
public class RateLimitingMiddleware(
    RequestDelegate next,
    ILogger<RateLimitingMiddleware> logger,
    RateLimitingOptions options)
{
    private static readonly ConcurrentDictionary<string, RequestLog> Clients = new();

    /// <summary>
    /// Applies rate limiting rules to the incoming request and forwards allowed requests to the next middleware.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        if (ShouldSkip(context.Request.Path))
        {
            await next(context);
            return;
        }

        var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        if (!IsRequestAllowed(clientIp))
        {
            logger.LogWarning("Rate limit exceeded for client {ClientIp}", clientIp);
            await ReturnRateLimitExceeded(context);
            return;
        }

        await next(context);
    }

    private bool ShouldSkip(PathString path)
    {
        return options.ExcludedPaths.Any(excludedPath => path.StartsWithSegments(excludedPath));
    }

    private bool IsRequestAllowed(string clientIp)
    {
        var now = DateTime.UtcNow;
        var windowStart = now.AddMinutes(-options.WindowMinutes);

        var requestLog = Clients.GetOrAdd(clientIp, _ => new RequestLog());

        lock (requestLog.Lock)
        {
            requestLog.Timestamps.RemoveAll(timestamp => timestamp < windowStart);

            if (requestLog.Timestamps.Count >= options.MaxRequests)
            {
                return false;
            }

            requestLog.Timestamps.Add(now);
            return true;
        }
    }

    private static async Task ReturnRateLimitExceeded(HttpContext context)
    {
        context.Response.StatusCode = 429;
        context.Response.Headers["Retry-After"] = "60";
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            error = "Rate limit exceeded",
            message = "Too many requests. Please try again later.",
            retryAfter = 60,
        });
    }
}

/// <summary>
/// Tracks recent request timestamps for a single client.
/// </summary>
public class RequestLog
{
    public List<DateTime> Timestamps { get; } = new();
    public object Lock { get; } = new();
}

/// <summary>
/// Configuration options for <see cref="RateLimitingMiddleware"/>.
/// </summary>
public class RateLimitingOptions
{
    public int MaxRequests { get; set; } = 100;
    public int WindowMinutes { get; set; } = 1;
    public string[] ExcludedPaths { get; set; } = Array.Empty<string>();
}

