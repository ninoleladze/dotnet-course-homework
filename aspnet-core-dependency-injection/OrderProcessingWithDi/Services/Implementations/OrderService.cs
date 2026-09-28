using OrderProcessingWithDi.Models;
using OrderProcessingWithDi.Services.Interfaces;

namespace OrderProcessingWithDi.Services.Implementations;

/// <summary>
/// Order processing service.
/// Demonstrates constructor injection with multiple dependencies.
/// </summary>
public class OrderService : IOrderService
{
    private readonly IPricingService pricingService;
    private readonly IOrderRepository repository;
    private readonly IOrderValidator validator;

    public OrderService(IPricingService pricingService, IOrderRepository repository, IOrderValidator validator)
    {
        this.pricingService = pricingService;
        this.repository = repository;
        this.validator = validator;
    }

    public Task<OrderResult> ProcessOrderAsync(string productId, int quantity, decimal unitPrice)
    {
        var (isValid, errorMessage) = validator.Validate(productId, quantity, unitPrice);
        if (!isValid)
        {
            throw new ArgumentException(errorMessage);
        }

        return SaveOrderAsync(productId, quantity, unitPrice);
    }

    private async Task<OrderResult> SaveOrderAsync(string productId, int quantity, decimal unitPrice)
    {
        var total = pricingService.CalculateTotal(unitPrice, quantity);
        var result = new OrderResult(productId, quantity, total);

        await repository.SaveAsync(result);

        return result;
    }
}
