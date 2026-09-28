namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;
using StoreDAL.Security;

/// <summary>
/// Business logic for managing store users: registration, authentication and profile management.
/// </summary>
public class UserService : ICrud
{
    /// <summary>
    /// The identifier of the "Registered" role, matching the fixed user-role seed data
    /// (see <see cref="StoreDAL.Data.InitDataFactory.TestDataFactory.GetUserRoleData"/>).
    /// </summary>
    private const int RegisteredRoleId = 2;

    private readonly IUserRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public UserService(StoreDbContext context)
    {
        this.repository = new UserRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (UserModel)model;
        this.repository.Add(new User(x.Id, x.Name, x.LastName, x.Login, x.Password, x.RoleId));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(ToModel);
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return ToModel(res);
    }

    /// <summary>
    /// Updates a user's profile information (name, last name, login, role). The password is left untouched;
    /// use <see cref="ChangePassword(int, string)"/> to change it.
    /// </summary>
    /// <param name="model">The model with updated values.</param>
    public void Update(AbstractModel model)
    {
        var x = (UserModel)model;
        var existing = this.repository.GetById(x.Id);
        if (existing == null)
        {
            throw new InvalidOperationException($"User with id {x.Id} was not found.");
        }

        existing.Name = x.Name;
        existing.LastName = x.LastName;
        existing.Login = x.Login;
        existing.RoleId = x.RoleId;
        this.repository.Update(existing);
    }

    /// <summary>
    /// Registers a new guest as a "Registered" user. Guests use this instead of <see cref="Add(AbstractModel)"/>
    /// so they cannot pick their own role.
    /// </summary>
    /// <param name="name">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    /// <param name="login">The desired unique login.</param>
    /// <param name="password">The plain-text password to hash and store.</param>
    /// <returns>The newly created user.</returns>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="login"/> is already taken.</exception>
    public UserModel Register(string name, string lastName, string login, string password)
    {
        ArgumentNullException.ThrowIfNull(login);
        if (this.repository.GetByLogin(login) != null)
        {
            throw new InvalidOperationException($"Login '{login}' is already taken.");
        }

        var entity = new User(0, name, lastName, login, password, RegisteredRoleId);
        this.repository.Add(entity);
        return ToModel(entity);
    }

    /// <summary>
    /// Verifies a login/password pair against stored users.
    /// </summary>
    /// <param name="login">The login to look up.</param>
    /// <param name="password">The plain-text password to verify.</param>
    /// <returns>The matching user on success; otherwise <see langword="null"/>.</returns>
    public UserModel? Authenticate(string login, string password)
    {
        var user = this.repository.GetByLogin(login);
        if (user == null || !PasswordHasher.Verify(password, user.Password))
        {
            return null;
        }

        return ToModel(user);
    }

    /// <summary>
    /// Changes a user's password.
    /// </summary>
    /// <param name="userId">The identifier of the user whose password will change.</param>
    /// <param name="newPassword">The new plain-text password to hash and store.</param>
    public void ChangePassword(int userId, string newPassword)
    {
        var user = this.repository.GetById(userId);
        if (user == null)
        {
            throw new InvalidOperationException($"User with id {userId} was not found.");
        }

        user.Password = PasswordHasher.Hash(newPassword);
        this.repository.Update(user);
    }

    private static UserModel ToModel(User entity)
    {
        return new UserModel(entity.Id, entity.Name, entity.LastName, entity.Login, string.Empty, entity.RoleId)
        {
            RoleName = entity.Role?.RoleName,
        };
    }
}
