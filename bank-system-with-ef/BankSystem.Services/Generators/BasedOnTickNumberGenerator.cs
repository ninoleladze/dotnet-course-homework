using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

/// <summary>
/// Generates a unique number based on the elapsed ticks since a starting point in time.
/// </summary>
public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    private readonly DateTime startingPoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasedOnTickUniqueNumberGenerator"/> class.
    /// </summary>
    /// <param name="startingPoint">The starting point in time from which the ticks are counted.</param>
    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }

    /// <inheritdoc/>
    public string Generate()
    {
        var elapsedTicks = (DateTime.Now - this.startingPoint).Ticks;
        return elapsedTicks.ToString(CultureInfo.InvariantCulture).GenerateHash();
    }
}
