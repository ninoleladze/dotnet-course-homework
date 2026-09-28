namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="Product"/> entities.
/// </summary>
public class ProductRepository : AbstractRepository, IProductRepository
{
    private readonly DbSet<Product> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ProductRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<Product>();
    }

    /// <inheritdoc/>
    public void Add(Product entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(Product entity)
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
    public IEnumerable<Product> GetAll()
    {
        return this.dbSet.Include(x => x.Title).ThenInclude(x => x.Category).Include(x => x.Manufacturer).ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<Product> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.Include(x => x.Title).ThenInclude(x => x.Category).Include(x => x.Manufacturer)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * rowCount)
            .Take(rowCount)
            .ToList();
    }

    /// <inheritdoc/>
    public Product GetById(int id)
    {
        return this.dbSet.Include(x => x.Title).ThenInclude(x => x.Category).Include(x => x.Manufacturer)
            .FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc/>
    public void Update(Product entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
