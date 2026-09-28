namespace BankSystem.Services.Generators;

/// <summary>
/// Defines a contract for generating unique string identifiers.
/// </summary>
public interface IUniqueNumberGenerator
{
    /// <summary>
    /// Generates a string that represents a unique number.
    /// </summary>
    /// <returns>A string representing a unique number.</returns>
    string Generate();
}
