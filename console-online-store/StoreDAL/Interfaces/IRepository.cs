namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDAL.Entities;

/// <summary>
/// Generic CRUD contract implemented by every entity repository.
/// </summary>
/// <typeparam name="TEntity">The entity type the repository manages.</typeparam>
public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Gets every entity.
    /// </summary>
    /// <returns>All entities.</returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Gets a single page of entities.
    /// </summary>
    /// <param name="pageNumber">The 1-based page number.</param>
    /// <param name="rowCount">The number of entities per page.</param>
    /// <returns>The requested page of entities.</returns>
    IEnumerable<TEntity> GetAll(int pageNumber, int rowCount);

    /// <summary>
    /// Finds a single entity by its identifier.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    /// <returns>The matching entity, or <see langword="null"/> if none is found.</returns>
    TEntity GetById(int id);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Removes an entity.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Removes an entity by its identifier. A no-op if no entity has that identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to remove.</param>
    void DeleteById(int id);

    /// <summary>
    /// Persists changes to an existing entity.
    /// </summary>
    /// <param name="entity">The entity carrying the new values.</param>
    void Update(TEntity entity);
}
