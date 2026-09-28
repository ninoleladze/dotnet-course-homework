using OrderProcessingWithDi.Services.Interfaces;

namespace OrderProcessingWithDi.Middleware;

/// <summary>
/// Middleware demonstrating DI in ASP.NET Core middleware.
/// Shows how services are injected into middleware via constructor.
/// </summary>
public class DependencyInjectionDemoMiddleware
{
    private readonly RequestDelegate next;

    /// <summary>
    /// Initializes a new instance of the <see cref="DependencyInjectionDemoMiddleware"/> class.
    /// </summary>
    public DependencyInjectionDemoMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// Invokes the middleware to demonstrate DI lifetimes.
    /// Keyed services are resolved per-request from the request's scoped provider, since
    /// this middleware itself is only constructed once using the root service provider.
    /// Adds instance IDs to response headers for each lifetime type.
    /// </summary>
    public Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return this.InvokeCoreAsync(context);
    }

    private async Task InvokeCoreAsync(HttpContext context)
    {
        var singletonService = context.RequestServices.GetRequiredKeyedService<ILifetimeDemoService>("singleton");
        var scopedService = context.RequestServices.GetRequiredKeyedService<ILifetimeDemoService>("scoped");
        var transientService = context.RequestServices.GetRequiredKeyedService<ILifetimeDemoService>("transient");

        context.Response.Headers.Append("X-DI-Singleton-Instance", singletonService.InstanceId);
        context.Response.Headers.Append("X-DI-Scoped-Instance", scopedService.InstanceId);
        context.Response.Headers.Append("X-DI-Transient-Instance", transientService.InstanceId);

        await this.next(context);
    }
}

/// <summary>
/// Extension method for registering middleware.
/// </summary>
public static class DependencyInjectionDemoMiddlewareExtensions
{
    /// <summary>
    /// Adds the DependencyInjectionDemoMiddleware to the application pipeline.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseDependencyInjectionDemo(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<DependencyInjectionDemoMiddleware>();
    }
}

