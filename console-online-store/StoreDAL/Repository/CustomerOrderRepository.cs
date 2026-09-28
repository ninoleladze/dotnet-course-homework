namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="CustomerOrder"/> entities.
/// </summary>
public class CustomerOrderRepository : AbstractRepository, ICustomerOrderRepository
{
    private readonly DbSet<CustomerOrder> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrderRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public CustomerOrderRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<CustomerOrder>();
    }

    /// <inheritdoc/>
    public void Add(CustomerOrder entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(CustomerOrder entity)
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
    public IEnumerable<CustomerOrder> GetAll()
    {
        return this.dbSet.Include(x => x.User).Include(x => x.State).Include(x => x.Details).ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<CustomerOrder> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.Include(x => x.User).Include(x => x.State).Include(x => x.Details)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * rowCount)
            .Take(rowCount)
            .ToList();
    }

    /// <inheritdoc/>
    public CustomerOrder GetById(int id)
    {
        return this.dbSet.Include(x => x.User).Include(x => x.State).Include(x => x.Details)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.Title)
            .FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc/>
    public IEnumerable<CustomerOrder> GetByUserId(int userId)
    {
        return this.dbSet.Include(x => x.State).Include(x => x.Details)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Id)
            .ToList();
    }

    /// <inheritdoc/>
    public void Update(CustomerOrder entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
