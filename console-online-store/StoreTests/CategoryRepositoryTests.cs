namespace StoreTests;

using StoreDAL.Entities;
using StoreDAL.Repository;

/// <summary>
/// Verifies <see cref="CategoryRepository"/> CRUD operations directly against the data access layer.
/// </summary>
public class CategoryRepositoryTests
{
    [Fact]
    public void Add_ThenGetById_ReturnsTheNewCategory()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new CategoryRepository(context);

        repository.Add(new Category(100, "toys"));
        var fetched = repository.GetById(100);

        Assert.NotNull(fetched);
        Assert.Equal("toys", fetched.Name);
    }

    [Fact]
    public void Update_ChangesTheStoredName()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new CategoryRepository(context);
        repository.Add(new Category(100, "toys"));

        repository.Update(new Category(100, "board games"));

        Assert.Equal("board games", repository.GetById(100).Name);
    }

    [Fact]
    public void DeleteById_RemovesTheCategory()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new CategoryRepository(context);
        repository.Add(new Category(100, "toys"));

        repository.DeleteById(100);

        Assert.Null(repository.GetById(100));
    }

    [Fact]
    public void GetAll_IncludesSeededCategories()
    {
        using var context = TestDbContextFactory.Create();
        var repository = new CategoryRepository(context);

        var categories = repository.GetAll().ToList();

        Assert.Contains(categories, c => c.Name == "fruits");
    }
}
