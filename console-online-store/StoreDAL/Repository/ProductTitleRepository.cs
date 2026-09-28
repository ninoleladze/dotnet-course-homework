namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="ProductTitle"/> entities.
/// </summary>
public class ProductTitleRepository : AbstractRepository, IProductTitleRepository
{
    private readonly DbSet<ProductTitle> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTitleRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ProductTitleRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<ProductTitle>();
    }

    /// <inheritdoc/>
    public void Add(ProductTitle entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(ProductTitle entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Remove(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void DeleteById(int id)
    {
        var entity = this.dbSet.Find(id);
        if (entity != null)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }
    }

    /// <inheritdoc/>
    public IEnumerable<ProductTitle> GetAll()
    {
        return this.dbSet.Include(x => x.Category).ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<ProductTitle> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.Include(x => x.Category)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * rowCount)
            .Take(rowCount)
            .ToList();
    }

    /// <inheritdoc/>
    public ProductTitle GetById(int id)
    {
        return this.dbSet.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc/>
    public void Update(ProductTitle entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
