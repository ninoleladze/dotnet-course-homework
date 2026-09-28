using System.Globalization;
using System.Text.RegularExpressions;

namespace BankSystem.Services.Helpers;

/// <summary>
/// Provides helper extension methods for validation needs.
/// </summary>
internal static class ValidationService
{
    private static readonly Regex EmailPattern = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Lazy<HashSet<string>> ValidCurrencyCodes = new(BuildValidCurrencyCodes);

    /// <summary>
    /// Checks whether the specified currency code is a known ISO currency code.
    /// </summary>
    /// <param name="currencyCode">The currency code to validate.</param>
    /// <returns><see langword="true"/> if the currency code is valid; otherwise, <see langword="false"/>.</returns>
    public static bool IsCurrencyValid(this string currencyCode)
    {
        return !string.IsNullOrWhiteSpace(currencyCode) && ValidCurrencyCodes.Value.Contains(currencyCode);
    }

    /// <summary>
    /// Checks whether the specified email address is in a correct format.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns><see langword="true"/> if the email address is valid; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmailValid(this string email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailPattern.IsMatch(email);
    }

    private static HashSet<string> BuildValidCurrencyCodes()
    {
        var codes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            try
            {
                var region = new RegionInfo(culture.Name);
                _ = codes.Add(region.ISOCurrencySymbol);
            }
            catch (ArgumentException)
            {
                // Some specific cultures do not map to a valid region.
            }
        }

        return codes;
    }
}
