using OrderProcessingWithDi.Middleware;
using OrderProcessingWithDi.Models;
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
        builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        builder.Services.AddKeyedSingleton<ILifetimeDemoService, LifetimeDemoService>("singleton");

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddKeyedScoped<ILifetimeDemoService, LifetimeDemoService>("scoped");

        builder.Services.AddTransient<IPricingService, PricingService>();
        builder.Services.AddKeyedTransient<ILifetimeDemoService, LifetimeDemoService>("transient");

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
        });

        app.MapGet("/orders", (IOrderRepository repository) => Results.Ok(repository.GetAll()));

        app.MapGet("/di-demo", (
            [FromKeyedServices("singleton")] ILifetimeDemoService singletonService,
            [FromKeyedServices("scoped")] ILifetimeDemoService scopedService,
            [FromKeyedServices("transient")] ILifetimeDemoService transientService) =>
        {
            return Results.Ok(new
            {
                singleton = new { instanceId = singletonService.InstanceId, createdAt = singletonService.CreatedAt },
                scoped = new { instanceId = scopedService.InstanceId, createdAt = scopedService.CreatedAt },
                transient = new { instanceId = transientService.InstanceId, createdAt = transientService.CreatedAt },
            });
        });

        app.MapGet("/factory-demo", (decimal price, int quantity, string? serviceType, IPricingServiceFactory factory) =>
        {
            var pricingService = factory.CreatePricingService(serviceType);
            var total = pricingService.CalculateTotal(price, quantity);

            return Results.Ok(new
            {
                message = "Factory pattern demo",
                serviceType = serviceType ?? "standard",
                price,
                quantity,
                total,
                explanation = $"Created via {pricingService.GetType().Name}",
            });
        });

        // ============================================================================
        // ROUTING TASK - Route Parameters and Constraints (legacy /orders routes)
        // ============================================================================
        app.MapGet("/orders/{orderId:int}", (int orderId, IOrderRepository repository) =>
        {
            var order = repository.GetById(orderId);
            return order is not null ? Results.Ok(order) : Results.NotFound();
        })
        .WithName("GetOrderByIdLegacy")
        .WithTags("Orders");

        app.MapGet("/orders/product/{productId:minlength(1)}", (string productId, IOrderRepository repository) =>
        {
            var orders = repository.GetAll().Where(o => o.ProductId == productId).ToList();
            return Results.Ok(orders);
        })
        .WithName("GetOrdersByProductIdLegacy")
        .WithTags("Orders");

        app.MapGet("/orders/range/{minTotal:decimal}/{maxTotal:decimal}", (decimal minTotal, decimal maxTotal, IOrderRepository repository) =>
        {
            var orders = repository.GetAll().Where(o => o.Total >= minTotal && o.Total <= maxTotal).ToList();
            return Results.Ok(orders);
        })
        .WithName("GetOrdersByTotalRangeLegacy")
        .WithTags("Orders");

        // ============================================================================
        // ROUTING TASK - Route Groups
        // ============================================================================
        var ordersGroup = app.MapGroup("/api/v1/orders").WithTags("Orders API v1");

        ordersGroup.MapPost("", async (string productId, int quantity, decimal unitPrice, IOrderService orderService) =>
        {
            var result = await orderService.ProcessOrderAsync(productId, quantity, unitPrice);
            return Results.Ok(result);
        });

        ordersGroup.MapGet("", (IOrderRepository repository) => Results.Ok(repository.GetAll()));

        ordersGroup.MapGet("/{orderId:int}", (int orderId, IOrderRepository repository) =>
        {
            var order = repository.GetById(orderId);
            return order is not null ? Results.Ok(order) : Results.NotFound();
        })
        .WithName("GetOrderById");

        ordersGroup.MapGet("/product/{productId:minlength(1)}", (string productId, IOrderRepository repository) =>
        {
            var orders = repository.GetAll().Where(o => o.ProductId == productId).ToList();
            return Results.Ok(orders);
        })
        .WithName("GetOrdersByProductId");

        ordersGroup.MapGet("/range/{minTotal:decimal}/{maxTotal:decimal}", (decimal minTotal, decimal maxTotal, IOrderRepository repository) =>
        {
            var orders = repository.GetAll().Where(o => o.Total >= minTotal && o.Total <= maxTotal).ToList();
            return Results.Ok(orders);
        })
        .WithName("GetOrdersByTotalRange");

        // ============================================================================
        // ROUTING TASK - Optional Parameters and Defaults
        // ============================================================================
        ordersGroup.MapGet("/search", (string? productId, decimal? minTotal, decimal? maxTotal, int? limit, IOrderRepository repository) =>
        {
            IEnumerable<OrderResult> orders = repository.GetAll();

            if (!string.IsNullOrEmpty(productId))
            {
                orders = orders.Where(o => o.ProductId == productId);
            }

            if (minTotal.HasValue)
            {
                orders = orders.Where(o => o.Total >= minTotal.Value);
            }

            if (maxTotal.HasValue)
            {
                orders = orders.Where(o => o.Total <= maxTotal.Value);
            }

            if (limit.HasValue)
            {
                orders = orders.Take(limit.Value);
            }

            return Results.Ok(orders.ToList());
        })
        .WithName("SearchOrders");

        // ============================================================================
        // ROUTING TASK - Route Constraints - Advanced
        // ============================================================================
        ordersGroup.MapGet("/recent/{days:int:range(1,30)}", (int days, IOrderRepository repository) =>
        {
            // OrderResult does not track a creation timestamp in this project,
            // so all orders are returned regardless of the requested day window.
            return Results.Ok(repository.GetAll());
        })
        .WithName("GetRecentOrders");

        // ============================================================================
        // ROUTING TASK - Custom Route Handler with Route Values
        // ============================================================================
        ordersGroup.MapGet("/stats", (HttpContext context, IOrderRepository repository) =>
        {
            var orders = repository.GetAll();

            if (orders.Count == 0)
            {
                return Results.Ok(new
                {
                    totalOrders = 0,
                    totalRevenue = 0m,
                    averageOrderTotal = 0m,
                    mostOrderedProductId = (string?)null,
                });
            }

            var totalOrders = orders.Count;
            var totalRevenue = orders.Sum(o => o.Total);
            var averageOrderTotal = totalRevenue / totalOrders;
            var mostOrderedProductId = orders
                .GroupBy(o => o.ProductId)
                .OrderByDescending(g => g.Sum(o => o.Quantity))
                .First()
                .Key;

            return Results.Ok(new
            {
                totalOrders,
                totalRevenue,
                averageOrderTotal,
                mostOrderedProductId,
            });
        })
        .WithName("GetOrderStatistics");

        // ============================================================================
        // ROUTING TASK - Route Ordering and Precedence
        // ============================================================================
        // NOTE: Registered last so specific routes above (e.g. {orderId:int}) take
        // precedence for numeric segments.
        ordersGroup.MapGet("/{id}", (string id, IOrderRepository repository) =>
        {
            if (int.TryParse(id, out var orderId))
            {
                var order = repository.GetById(orderId);
                return order is not null ? Results.Ok(order) : Results.NotFound();
            }

            var orders = repository.GetAll().Where(o => o.ProductId == id).ToList();
            return orders.Count > 0 ? Results.Ok(orders) : Results.NotFound();
        })
        .WithName("GetOrderByAnyId");

        app.Run();
    }
}
