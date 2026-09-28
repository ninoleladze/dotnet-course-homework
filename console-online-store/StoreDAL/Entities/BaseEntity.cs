namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Base class for every persisted entity, providing the shared integer primary key.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class with the given identifier.
    /// </summary>
    /// <param name="id">The entity's primary key.</param>
    protected BaseEntity(int id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class with a default (unset) identifier.
    /// </summary>
    protected BaseEntity()
    {
        this.Id = 0;
    }

    /// <summary>
    /// Gets or sets the entity's primary key.
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
}
