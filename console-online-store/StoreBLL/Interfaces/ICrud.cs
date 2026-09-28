namespace StoreBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Models;

/// <summary>
/// Generic CRUD contract implemented by every business-logic service, driving the presentation
/// layer's add/remove/edit/view menu (see <c>ConsoleApp.Handlers.ContextMenuHandlers</c>).
/// </summary>
public interface ICrud
{
    /// <summary>
    /// Gets every record as its BLL model.
    /// </summary>
    /// <returns>All records.</returns>
    IEnumerable<AbstractModel> GetAll();

    /// <summary>
    /// Finds a single record by its identifier.
    /// </summary>
    /// <param name="id">The record identifier.</param>
    /// <returns>The matching record.</returns>
    AbstractModel GetById(int id);

    /// <summary>
    /// Adds a new record.
    /// </summary>
    /// <param name="model">The record to add.</param>
    void Add(AbstractModel model);

    /// <summary>
    /// Persists changes to an existing record.
    /// </summary>
    /// <param name="model">The record carrying the new values.</param>
    void Update(AbstractModel model);

    /// <summary>
    /// Removes a record by its identifier.
    /// </summary>
    /// <param name="modelId">The identifier of the record to remove.</param>
    void Delete(int modelId);
}
