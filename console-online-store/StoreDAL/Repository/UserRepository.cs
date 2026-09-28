namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Security;

/// <summary>
/// EF Core backed repository for <see cref="User"/> entities.
/// </summary>
public class UserRepository : AbstractRepository, IUserRepository
{
    private readonly DbSet<User> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public UserRepository(StoreDbContext context)
        : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.dbSet = context.Set<User>();
    }

    /// <summary>
    /// Adds a new user, hashing the plain-text password before it is persisted.
    /// </summary>
    /// <param name="entity">The user to add. Its <see cref="User.Password"/> must be plain text.</param>
    public void Add(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        entity.Password = PasswordHasher.Hash(entity.Password);
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(User entity)
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
    public IEnumerable<User> GetAll()
    {
        return this.dbSet.Include(x => x.Role).ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<User> GetAll(int pageNumber, int rowCount)
    {
        return this.dbSet.Include(x => x.Role)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * rowCount)
            .Take(rowCount)
            .ToList();
    }

    /// <inheritdoc/>
    public User GetById(int id)
    {
        return this.dbSet.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc/>
    public User? GetByLogin(string login)
    {
        ArgumentNullException.ThrowIfNull(login);
        return this.dbSet.Include(x => x.Role).FirstOrDefault(x => x.Login == login);
    }

    /// <summary>
    /// Updates a user's data. The <see cref="User.Password"/> value is written as-is,
    /// so callers must already have hashed it if it changed.
    /// </summary>
    /// <param name="entity">The user with updated values.</param>
    public void Update(User entity)
    {
        this.UpdateTracked(this.dbSet, entity);
    }
}
