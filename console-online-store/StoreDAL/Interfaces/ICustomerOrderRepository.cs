namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDAL.Entities;

/// <summary>
/// Repository for <see cref="CustomerOrder"/> entities.
/// </summary>
public interface ICustomerOrderRepository : IRepository<CustomerOrder>
{
    /// <summary>
    /// Gets every order placed by a given customer, most recent first.
    /// </summary>
    /// <param name="userId">The identifier of the customer.</param>
    /// <returns>The customer's orders.</returns>
    IEnumerable<CustomerOrder> GetByUserId(int userId);
}
