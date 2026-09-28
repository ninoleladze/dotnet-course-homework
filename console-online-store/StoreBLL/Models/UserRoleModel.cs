namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// BLL-facing representation of a user role (e.g. Admin, Registered, Guest).
/// </summary>
public class UserRoleModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRoleModel"/> class.
    /// </summary>
    /// <param name="id">The role identifier.</param>
    /// <param name="roleName">The role name.</param>
    public UserRoleModel(int id, string roleName)
        : base(id)
    {
        this.Id = id;
        this.RoleName = roleName;
    }

    /// <summary>
    /// Gets or sets the role name.
    /// </summary>
    public string RoleName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.RoleName}";
    }
}
