using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;

namespace StoreDAL.Repository
{
    /// <summary>
    /// Base class for EF Core backed repositories, holding the shared <see cref="StoreDbContext"/>
    /// and a safe update helper all repositories can reuse.
    /// </summary>
    public abstract class AbstractRepository
    {
        protected readonly StoreDbContext context;

        protected AbstractRepository(StoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Persists changes for <paramref name="entity"/>, safely handling the case where a
        /// <em>different</em> instance with the same key is already tracked by the context (which
        /// routinely happens after a preceding <c>GetAll()</c>/<c>GetById()</c> call, e.g. the admin
        /// menu redrawing its "Current DataSet" listing right before an edit). Calling
        /// <see cref="DbSet{TEntity}.Update"/> directly on a second, detached instance in that
        /// situation throws <see cref="InvalidOperationException"/>; this copies the new values into
        /// the already-tracked instance instead.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="dbSet">The set the entity belongs to.</param>
        /// <param name="entity">The entity carrying the new values to persist.</param>
        protected void UpdateTracked<TEntity>(DbSet<TEntity> dbSet, TEntity entity)
            where TEntity : BaseEntity
        {
            ArgumentNullException.ThrowIfNull(dbSet);
            ArgumentNullException.ThrowIfNull(entity);

            var tracked = dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);
            if (tracked != null && !ReferenceEquals(tracked, entity))
            {
                this.context.Entry(tracked).CurrentValues.SetValues(entity);
            }
            else
            {
                dbSet.Update(entity);
            }

            this.context.SaveChanges();
        }
    }
}
