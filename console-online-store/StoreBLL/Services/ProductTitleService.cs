namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

/// <summary>
/// Business logic for managing product titles (the named products within a category). Administrator-only.
/// </summary>
public class ProductTitleService : ICrud
{
    private readonly IProductTitleRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTitleService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ProductTitleService(StoreDbContext context)
    {
        this.repository = new ProductTitleRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (ProductTitleModel)model;
        this.repository.Add(new ProductTitle(x.Id, x.Title, x.CategoryId));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(ToModel);
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return ToModel(res);
    }

    /// <inheritdoc/>
    public void Update(AbstractModel model)
    {
        var x = (ProductTitleModel)model;
        var existing = this.repository.GetById(x.Id);
        if (existing == null)
        {
            throw new InvalidOperationException($"Product title with id {x.Id} was not found.");
        }

        existing.Title = x.Title;
        existing.CategoryId = x.CategoryId;
        this.repository.Update(existing);
    }

    private static ProductTitleModel ToModel(ProductTitle entity)
    {
        return new ProductTitleModel(entity.Id, entity.Title, entity.CategoryId)
        {
            CategoryName = entity.Category?.Name,
        };
    }
}
