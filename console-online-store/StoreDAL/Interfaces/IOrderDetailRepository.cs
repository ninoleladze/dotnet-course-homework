namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDAL.Entities;

/// <summary>
/// Repository for <see cref="OrderDetail"/> entities.
/// </summary>
public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    /// <summary>
    /// Gets every line item that belongs to a given order.
    /// </summary>
    /// <param name="orderId">The identifier of the owning order.</param>
    /// <returns>The order's line items.</returns>
    IEnumerable<OrderDetail> GetByOrderId(int orderId);
}
