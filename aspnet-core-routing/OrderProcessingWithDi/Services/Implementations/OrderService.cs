using OrderProcessingWithDi.Models;
using OrderProcessingWithDi.Services.Interfaces;

namespace OrderProcessingWithDi.Services.Implementations;

/// <summary>
/// Order processing service.
/// Demonstrates constructor injection of multiple dependencies:
/// IPricingService, IOrderRepository, and IOrderValidator.
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
        var (isValid, errorMessage) = this.validator.Validate(productId, quantity, unitPrice);
        if (!isValid)
        {
            throw new ArgumentException(errorMessage);
        }

        return this.ProcessOrderCoreAsync(productId, quantity, unitPrice);
    }

    private async Task<OrderResult> ProcessOrderCoreAsync(string productId, int quantity, decimal unitPrice)
    {
        var total = this.pricingService.CalculateTotal(unitPrice, quantity);
        var result = new OrderResult(productId, quantity, total);
        await this.repository.SaveAsync(result);

        return result;
    }
}

