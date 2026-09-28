using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

/// <summary>
/// Generates a unique number based on a globally unique identifier (GUID).
/// </summary>
public class GuidNumberGenerator : IUniqueNumberGenerator
{
    /// <inheritdoc/>
    public string Generate() => Guid.NewGuid().ToString().GenerateHash();
}
