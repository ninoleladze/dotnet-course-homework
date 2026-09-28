using BankSystem.EF.Entities;

namespace BankSystem.Services.Services;

public abstract class BaseService : IDisposable
{
    protected BaseService(BankContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.Context = context;
    }

    protected BankContext Context { get; }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.Context.Dispose();
        }
    }
}
