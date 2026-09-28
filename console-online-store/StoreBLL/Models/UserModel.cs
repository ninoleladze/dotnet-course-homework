namespace StoreBLL.Models;

/// <summary>
/// BLL-facing representation of a store user (guest registration, personal info, admin management).
/// </summary>
public class UserModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserModel"/> class.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <param name="name">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    /// <param name="login">The unique login used to sign in.</param>
    /// <param name="password">
    /// The plain-text password. It is hashed by the data access layer before being persisted
    /// and is never populated back from storage.
    /// </param>
    /// <param name="roleId">The identifier of the user's role.</param>
    public UserModel(int id, string name, string lastName, string login, string password, int roleId)
        : base(id)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Login = login;
        this.Password = password;
        this.RoleId = roleId;
    }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the login used to sign in.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the password. Plain text on input, never populated with the stored hash on output.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user's role.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user's role, when known.
    /// </summary>
    public string? RoleName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.Name} {this.LastName} login:{this.Login} role:{this.RoleName ?? this.RoleId.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
    }
}
