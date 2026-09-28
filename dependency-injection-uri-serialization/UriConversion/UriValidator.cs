using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;
using Validation;

namespace UriConversion;

/// <summary>
/// Uri string validator.
/// </summary>
public class UriValidator : IValidator<string>
{
    private readonly ILogger<UriValidator>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UriValidator"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public UriValidator(ILogger<UriValidator>? logger = default)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Determines if a string is valid Uri.
    /// </summary>
    /// <param name="obj">The source string.</param>
    /// <returns>true if the uri string is valid; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Throw if source string is null.</exception>
    public bool IsValid(string? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        bool isValid = Uri.TryCreate(obj, UriKind.Absolute, out _);

        if (!isValid)
        {
            LogerExtension.FastLoggerMessage(this.logger, $"Invalid uri string: {obj}", new LogerExtensionException($"Invalid uri string: {obj}"));
        }

        return isValid;
    }
}
