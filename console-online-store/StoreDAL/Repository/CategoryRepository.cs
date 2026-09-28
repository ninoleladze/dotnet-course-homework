namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="Category"/> entities.
/// </summary>
public class CategoryRepository : AbstractRepository, ICategoryRepository
{
    private readonly DbSet<Category> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public CategoryRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<Category>();
    }

    /// <inheritdoc/>
    public void Add(Category entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(Category entity)
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
    public IEnumerable<Category> GetAll()
    {
        return this.dbSet.ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<Category> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.OrderBy(x => x.Id).Skip((pageNumber - 1) * rowCount).Take(rowCount).ToList();
    }

    /// <inheritdoc/>
    public Category GetById(int id)
    {
        return this.dbSet.Find(id);
    }

    /// <inheritdoc/>
    public void Update(Category entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
