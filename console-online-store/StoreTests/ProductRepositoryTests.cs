namespace StoreTests;

using StoreDAL.Repository;

/// <summary>
/// Verifies <see cref="ProductRepository"/> loads related title/category/manufacturer data.
/// </summary>
public class ProductRepositoryTests
{
    [Fact]
    public void GetById_IncludesTitleCategoryAndManufacturer()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new ProductRepository(context);

        var product = repository.GetById(1);

        Assert.NotNull(product);
        Assert.NotNull(product.Title);
        Assert.NotNull(product.Title.Category);
        Assert.NotNull(product.Manufacturer);
    }

    [Fact]
    public void GetAll_Paged_ReturnsRequestedPageSize()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new ProductRepository(context);

        var page = repository.GetAll(1, 5).ToList();

        Assert.Equal(5, page.Count);
    }
}
