using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class ProductReportService : IDisposable
{
    private readonly ShopContext shopContext;

    public ProductReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public ProductCategoryReport GetProductCategoryReport()
    {
        var lines = this.shopContext.Categories
            .OrderBy(category => category.Name)
            .Select(category => new ProductCategoryReportLine
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
            })
            .ToList();

        return new ProductCategoryReport(lines, DateTime.Now);
    }

    public ProductReport GetProductReport()
    {
        var lines = this.shopContext.Products
            .OrderByDescending(product => product.Title.Title)
            .Select(product => new ProductReportLine
            {
                ProductId = product.Id,
                ProductTitle = product.Title.Title,
                Manufacturer = product.Manufacturer.Name,
                Price = product.UnitPrice,
            })
            .ToList();

        return new ProductReport(lines, DateTime.Now);
    }

    public FullProductReport GetFullProductReport()
    {
        var lines = this.shopContext.Products
            .OrderBy(product => product.Title.Title)
            .Select(product => new FullProductReportLine
            {
                ProductId = product.Id,
                Name = product.Title.Title,
                CategoryId = product.Title.CategoryId,
                Manufacturer = product.Manufacturer.Name,
                Price = product.UnitPrice,
                Category = product.Title.Category.Name,
            })
            .ToList();

        return new FullProductReport(lines, DateTime.Now);
    }

    public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
    {
        var lines = this.shopContext.OrderDetails
            .GroupBy(detail => detail.Product.Title.Title)
            .Select(group => new ProductTitleSalesRevenueReportLine
            {
                ProductTitleName = group.Key,
                SalesRevenue = group.Sum(detail => detail.PriceWithDiscount),
                SalesAmount = group.Sum(detail => detail.ProductAmount),
            })
            .OrderByDescending(line => line.SalesRevenue)
            .ToList();

        return new ProductTitleSalesRevenueReport(lines, DateTime.Now);
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
