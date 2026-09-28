namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDAL.Entities;

/// <summary>
/// Repository for <see cref="Product"/> entities.
/// </summary>
public interface IProductRepository : IRepository<Product>
{
}
