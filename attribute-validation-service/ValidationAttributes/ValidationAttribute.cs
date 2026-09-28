namespace ValidationAttributes;

/// <summary>
/// Base abstract class for custom validation attributes.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
#pragma warning disable CA1813 // Avoid unsealed attributes - must be abstract for inheritance
public abstract class ValidationAttribute : Attribute
#pragma warning restore CA1813
{
    private string errorMessage = "The field is invalid.";

    /// <summary>
    /// Initializes a new instance of the ValidationAttribute class with the default error message.
    /// </summary>
    protected ValidationAttribute()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ValidationAttribute class with a custom error message.
    /// </summary>
    /// <param name="errorMessage">The error message to display if validation fails.</param>
    protected ValidationAttribute(string errorMessage)
    {
        this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Gets or sets the error message associated with the validation attribute.
    /// </summary>
    public string ErrorMessage
    {
        get => this.errorMessage;
        set => this.errorMessage = value ?? "The field is invalid.";
    }

    /// <summary>
    /// Determines whether the specified value is valid.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>true if the value is valid; otherwise, false.</returns>
    public abstract bool IsValid(object? value);
}
