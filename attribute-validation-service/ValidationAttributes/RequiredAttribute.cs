namespace ValidationAttributes;

/// <summary>
/// Specifies that a data field value is required.
/// </summary>
#pragma warning disable CA1813 // Avoid unsealed attributes
public class RequiredAttribute : ValidationAttribute
#pragma warning restore CA1813
{
    /// <summary>
    /// Initializes a new instance of the RequiredAttribute class with the default error message.
    /// </summary>
    public RequiredAttribute()
        : base("The field is required.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the RequiredAttribute class with a custom error message.
    /// </summary>
    /// <param name="errorMessage">The error message to display if validation fails.</param>
    public RequiredAttribute(string errorMessage)
        : base(errorMessage)
    {
    }

    /// <summary>
    /// Determines whether the specified value is valid (not null and not an empty string).
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>true if the value is not null and not an empty string; otherwise, false.</returns>
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return false;
        }

        // Treat empty strings as invalid
        if (value is string str && str.Length == 0)
        {
            return false;
        }

        return true;
    }
}
