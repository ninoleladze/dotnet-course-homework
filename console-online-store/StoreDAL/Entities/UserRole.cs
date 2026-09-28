namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A role a <see cref="User"/> can have (e.g. Admin, Registered, Guest), controlling which store
/// functionality they can access.
/// </summary>
[Table("user_roles")]
public class UserRole : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    public UserRole()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    /// <param name="id">The role identifier.</param>
    /// <param name="roleName">The role name.</param>
    public UserRole(int id, string roleName)
        : base(id)
    {
        this.RoleName = roleName;
    }

    /// <summary>
    /// Gets or sets the role name.
    /// </summary>
    [Column("user_role_name")]
    public string RoleName { get; set; }

    /// <summary>
    /// Gets or sets the users that have this role.
    /// </summary>
    public virtual IList<User> User { get; set; }
}
