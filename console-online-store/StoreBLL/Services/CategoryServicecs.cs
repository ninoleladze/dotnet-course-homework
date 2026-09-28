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
/// Business logic for managing product categories. Administrator-only.
/// </summary>
public class CategoryService : ICrud
{
    private readonly ICategoryRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public CategoryService(StoreDbContext context)
    {
        this.repository = new CategoryRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (CategoryModel)model;
        this.repository.Add(new Category(x.Id, x.Name));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new CategoryModel(x.Id, x.Name));
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new CategoryModel(res.Id, res.Name);
    }

    /// <inheritdoc/>
    public void Update(AbstractModel model)
    {
        var x = (CategoryModel)model;
        this.repository.Update(new Category(x.Id, x.Name));
    }
}
