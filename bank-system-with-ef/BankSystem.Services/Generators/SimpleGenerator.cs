using System.Globalization;
using System.Threading;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

/// <summary>
/// Generates sequential unique numbers. Implements the Singleton design pattern.
/// </summary>
public sealed class SimpleGenerator : IUniqueNumberGenerator
{
    private int lastNumber = 1234567890;

    private SimpleGenerator()
    {
    }

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    /// <summary>
    /// Gets the single instance of the <see cref="SimpleGenerator"/> class.
    /// </summary>
    public static SimpleGenerator Instance { get; }

    /// <inheritdoc/>
    public string Generate()
    {
        var next = Interlocked.Increment(ref this.lastNumber);
        return next.ToString(CultureInfo.InvariantCulture).GenerateHash();
    }
}
