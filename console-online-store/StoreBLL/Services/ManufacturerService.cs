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

/// <summary>
/// Business logic for managing product manufacturers. Administrator-only.
/// </summary>
public class ManufacturerService : ICrud
{
    private readonly IManufacturerRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManufacturerService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public ManufacturerService(StoreDbContext context)
    {
        this.repository = new ManufacturerRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (ManufacturerModel)model;
        this.repository.Add(new Manufacturer(x.Id, x.Name));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new ManufacturerModel(x.Id, x.Name));
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new ManufacturerModel(res.Id, res.Name);
    }

    /// <inheritdoc/>
    public void Update(AbstractModel model)
    {
        var x = (ManufacturerModel)model;
        this.repository.Update(new Manufacturer(x.Id, x.Name));
    }
}
