using OrderProcessingWithDi.Middleware;
using OrderProcessingWithDi.Services.Implementations;
using OrderProcessingWithDi.Services.Interfaces;

namespace OrderProcessingWithDi;

public class Program
{
    protected Program()
    {
    }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ============================================================================
        // ASPECT 1 - Service Lifetimes - Singleton, Scoped, Transient
        // ============================================================================
        // SINGLETON: One instance for the entire application lifetime
        builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        builder.Services.AddSingleton<ILifetimeDemoService>(sp => new LifetimeDemoService());

        // SCOPED: One instance per HTTP request
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<ILifetimeDemoService>(sp => new LifetimeDemoService());

        // TRANSIENT: New instance every time it's requested
        builder.Services.AddTransient<IPricingService, PricingService>();
        builder.Services.AddTransient<ILifetimeDemoService>(sp => new LifetimeDemoService());

        // ============================================================================
        // ASPECT 2 - Multiple Dependencies Injection
        // ============================================================================
        builder.Services.AddScoped<IOrderValidator, OrderValidator>();

        // ============================================================================
        // ASPECT 3 - Factory Pattern
        // ============================================================================
        builder.Services.AddSingleton<IPricingServiceFactory, PricingServiceFactory>();

        var app = builder.Build();

        // ============================================================================
        // ASPECT 4: Middleware with DI
        // ============================================================================
        app.UseDependencyInjectionDemo();

        // ============================================================================
        // ASPECT 5: Minimal API with Method Injection
        // ============================================================================
        app.MapPost("/orders", async (string productId, int quantity, decimal unitPrice, IOrderService orderService) =>
        {
            var result = await orderService.ProcessOrderAsync(productId, quantity, unitPrice);
            return Results.Ok(result);
        })
        .WithName("CreateOrder")
        .WithTags("Orders");

        app.MapGet("/orders", (IOrderRepository repository) =>
        {
            var orders = repository.GetAll();
            return Results.Ok(orders);
        })
        .WithName("GetAllOrders")
        .WithTags("Orders");

        app.MapGet("/di-demo", (
            ILifetimeDemoService singletonService,
            ILifetimeDemoService scopedService,
            ILifetimeDemoService transientService) =>
        {
            return Results.Ok(new
            {
                message = "Dependency Injection Lifetime Demonstration",
                singleton = new { instanceId = singletonService.InstanceId, createdAt = singletonService.CreatedAt },
                scoped = new { instanceId = scopedService.InstanceId, createdAt = scopedService.CreatedAt },
                transient = new { instanceId = transientService.InstanceId, createdAt = transientService.CreatedAt },
                explanation = new
                {
                    singleton = "Singleton: one instance for the entire application lifetime, shared across all requests.",
                    scoped = "Scoped: one instance per HTTP request, shared within that request.",
                    transient = "Transient: a new instance is created every time it is requested."
                }
            });
        })
        .WithName("DependencyInjectionDemo")
        .WithTags("DI Demo");

        app.MapGet("/factory-demo", (IPricingServiceFactory factory, decimal price, int quantity, string? serviceType) =>
        {
            var pricingService = factory.CreatePricingService(serviceType);
            var total = pricingService.CalculateTotal(price, quantity);

            return Results.Ok(new
            {
                message = "Factory Pattern Demonstration",
                serviceType = serviceType ?? "standard",
                price,
                quantity,
                total,
                explanation = "The factory creates a pricing service implementation based on the requested service type."
            });
        })
        .WithName("FactoryDemo")
        .WithTags("DI Demo");

        app.Run();
    }
}
