using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class CustomerReportService : IDisposable
{
    private readonly ShopContext shopContext;

    public CustomerReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
    {
        var lines = this.shopContext.OrderDetails
            .Where(detail => detail.Order.CustomerId != null)
            .GroupBy(detail => new
            {
                CustomerId = detail.Order.CustomerId!.Value,
                detail.Order.Customer!.Person.FirstName,
                detail.Order.Customer.Person.LastName,
            })
            .Select(group => new CustomerSalesRevenueReportLine
            {
                CustomerId = group.Key.CustomerId,
                PersonFirstName = group.Key.FirstName,
                PersonLastName = group.Key.LastName,
                SalesRevenue = group.Sum(detail => detail.PriceWithDiscount),
            })
            .OrderByDescending(line => line.SalesRevenue)
            .ToList();

        return new CustomerSalesRevenueReport(lines, DateTime.Now);
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.shopContext.Dispose();
        }
    }
}
