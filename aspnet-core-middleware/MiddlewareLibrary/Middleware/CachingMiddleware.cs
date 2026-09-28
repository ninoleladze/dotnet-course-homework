using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareLibrary.Middleware;

/// <summary>
/// Middleware that caches responses for configured paths to improve performance.
/// </summary>
public class CachingMiddleware(RequestDelegate next, ILogger<CachingMiddleware> logger, CachingOptions options)
{
    private static readonly ConcurrentDictionary<string, CacheEntry> Cache = new();

    /// <summary>
    /// Processes the incoming request with caching logic and serves a cached response when available.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        if (!ShouldCache(context.Request.Path))
        {
            await next(context);
            return;
        }

        var cacheKey = $"{context.Request.Method}:{context.Request.Path}:{context.Request.QueryString}";

        if (TryGetFromCache(cacheKey, out var cachedEntry))
        {
            logger.LogInformation("Cache HIT for {Path}", context.Request.Path);
            await WriteCachedResponse(context, cachedEntry!);
            return;
        }

        logger.LogInformation("Cache MISS for {Path}", context.Request.Path);

        var originalBodyStream = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            await next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var content = Encoding.UTF8.GetString(memoryStream.ToArray());

            var entry = new CacheEntry
            {
                Content = content,
                ContentType = context.Response.ContentType ?? string.Empty,
                StatusCode = context.Response.StatusCode,
                Expiration = DateTime.UtcNow.AddMinutes(options.CacheDurationMinutes),
            };

            SaveToCache(cacheKey, entry);
            AddCacheHeaders(context, entry);

            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBodyStream);
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private bool ShouldCache(PathString path)
    {
        return options.CacheablePaths.Any(prefix => path.StartsWithSegments(prefix));
    }

    private static bool TryGetFromCache(string cacheKey, out CacheEntry? entry)
    {
        if (Cache.TryGetValue(cacheKey, out var cached))
        {
            if (cached.Expiration > DateTime.UtcNow)
            {
                entry = cached;
                return true;
            }

            Cache.TryRemove(cacheKey, out _);
        }

        entry = null;
        return false;
    }

    private static void SaveToCache(string cacheKey, CacheEntry entry)
    {
        Cache[cacheKey] = entry;
    }

    private static void AddCacheHeaders(HttpContext context, CacheEntry entry)
    {
        context.Response.Headers["Cache-Control"] = $"public, max-age={entry.Expiration.Subtract(DateTime.UtcNow).TotalSeconds:F0}";
        context.Response.Headers["ETag"] = $"\"{Guid.NewGuid()}\"";
    }

    private static async Task WriteCachedResponse(HttpContext context, CacheEntry entry)
    {
        context.Response.StatusCode = entry.StatusCode;
        context.Response.ContentType = entry.ContentType;
        AddCacheHeaders(context, entry);
        await context.Response.WriteAsync(entry.Content);
    }
}

/// <summary>
/// Represents a cached response entry.
/// </summary>
public class CacheEntry
{
    public string Content { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public DateTime Expiration { get; set; }
}

/// <summary>
/// Configuration options for <see cref="CachingMiddleware"/>.
/// </summary>
public class CachingOptions
{
    public int CacheDurationMinutes { get; set; } = 60;
    public string[] CacheablePaths { get; set; } = Array.Empty<string>();
}

