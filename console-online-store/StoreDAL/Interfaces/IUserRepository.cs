namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDAL.Entities;

/// <summary>
/// Repository for <see cref="User"/> entities.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Finds a user by their unique login.
    /// </summary>
    /// <param name="login">The login to search for.</param>
    /// <returns>The matching <see cref="User"/>, or <see langword="null"/> if none is found.</returns>
    User? GetByLogin(string login);
}
