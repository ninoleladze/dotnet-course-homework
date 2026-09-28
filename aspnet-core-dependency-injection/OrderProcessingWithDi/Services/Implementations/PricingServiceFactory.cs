using OrderProcessingWithDi.Services.Interfaces;

namespace OrderProcessingWithDi.Services.Implementations;

/// <summary>
/// Factory implementation for creating pricing services.
/// </summary>
public class PricingServiceFactory : IPricingServiceFactory
{
    private readonly IServiceProvider serviceProvider;

    public PricingServiceFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IPricingService CreatePricingService(string? serviceType = null)
    {
        serviceType ??= "standard";

        return serviceType switch
        {
            "standard" => serviceProvider.GetRequiredService<IPricingService>(),
            "simple" => new SimplePricingService(),
            _ => throw new ArgumentException($"Unknown pricing service type: {serviceType}")
        };
    }
}
