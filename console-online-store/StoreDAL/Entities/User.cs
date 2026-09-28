namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A store account: a guest who registered, or an administrator.
/// </summary>
[Table("users")]
public class User : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    public User()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <param name="name">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    /// <param name="login">The unique login used to sign in.</param>
    /// <param name="password">The password hash to store (never plain text; see <see cref="StoreDAL.Security.PasswordHasher"/>).</param>
    /// <param name="roleId">The identifier of the user's role.</param>
    public User(int id, string name, string lastName, string login, string password, int roleId)
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
    [Column("first_name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    [Column("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the login used to sign in.
    /// </summary>
    [Column("login")]
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the password hash. Never plain text on read or write.
    /// </summary>
    [Column("Password")]
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user's role.
    /// </summary>
    [Column("user_role_id")]
    public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the user's role.
    /// </summary>
    [ForeignKey(nameof(RoleId))]
    public UserRole Role { get; set; }

    /// <summary>
    /// Gets or sets the orders this user has placed.
    /// </summary>
    public virtual IList<CustomerOrder> Order { get; set; }
}
