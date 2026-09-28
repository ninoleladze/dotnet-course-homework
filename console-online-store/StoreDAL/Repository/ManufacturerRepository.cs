namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="Manufacturer"/> entities.
/// </summary>
public class ManufacturerRepository : AbstractRepository, IManufacturerRepository
{
    private readonly DbSet<Manufacturer> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManufacturerRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ManufacturerRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<Manufacturer>();
    }

    /// <inheritdoc/>
    public void Add(Manufacturer entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(Manufacturer entity)
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
    public IEnumerable<Manufacturer> GetAll()
    {
        return this.dbSet.ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<Manufacturer> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.OrderBy(x => x.Id).Skip((pageNumber - 1) * rowCount).Take(rowCount).ToList();
    }

    /// <inheritdoc/>
    public Manufacturer GetById(int id)
    {
        return this.dbSet.Find(id);
    }

    /// <inheritdoc/>
    public void Update(Manufacturer entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
