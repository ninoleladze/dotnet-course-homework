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
/// Business logic for browsing and managing the store's product catalog.
/// </summary>
public class ProductService : ICrud
{
    private readonly IProductRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ProductService(StoreDbContext context)
    {
        this.repository = new ProductRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (ProductModel)model;
        this.repository.Add(new Product(x.Id, x.TitleId, x.ManufacturerId, x.Description, x.UnitPrice));
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
        var x = (ProductModel)model;
        var existing = this.repository.GetById(x.Id);
        if (existing == null)
        {
            throw new InvalidOperationException($"Product with id {x.Id} was not found.");
        }

        existing.TitleId = x.TitleId;
        existing.ManufacturerId = x.ManufacturerId;
        existing.UnitPrice = x.UnitPrice;
        existing.Description = x.Description;
        this.repository.Update(existing);
    }

    private static ProductModel ToModel(Product entity)
    {
        return new ProductModel(entity.Id, entity.TitleId, entity.ManufacturerId, entity.Description, entity.UnitPrice)
        {
            TitleName = entity.Title?.Title,
            CategoryName = entity.Title?.Category?.Name,
            ManufacturerName = entity.Manufacturer?.Name,
        };
    }
}
