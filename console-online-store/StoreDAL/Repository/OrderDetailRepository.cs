namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

/// <summary>
/// EF Core backed repository for <see cref="OrderDetail"/> entities.
/// </summary>
public class OrderDetailRepository : AbstractRepository, IOrderDetailRepository
{
    private readonly DbSet<OrderDetail> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetailRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public OrderDetailRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<OrderDetail>();
    }

    /// <inheritdoc/>
    public void Add(OrderDetail entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(OrderDetail entity)
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
    public IEnumerable<OrderDetail> GetAll()
    {
        return this.dbSet.Include(x => x.Product).ThenInclude(x => x.Title).ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<OrderDetail> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.Include(x => x.Product).ThenInclude(x => x.Title)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * rowCount)
            .Take(rowCount)
            .ToList();
    }

    /// <inheritdoc/>
    public OrderDetail GetById(int id)
    {
        return this.dbSet.Include(x => x.Product).ThenInclude(x => x.Title).FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc/>
    public IEnumerable<OrderDetail> GetByOrderId(int orderId)
    {
        return this.dbSet.Include(x => x.Product).ThenInclude(x => x.Title)
            .Where(x => x.OrderId == orderId)
            .ToList();
    }

    /// <inheritdoc/>
    public void Update(OrderDetail entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
