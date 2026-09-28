namespace ValidationServiceTask;

/// <summary>
/// Stores information about a validation error.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Gets the type of the validation attribute that failed.
    /// </summary>
    public Type ValidationType { get; }

    /// <summary>
    /// Gets the validation error message.
    /// </summary>
    public string ValidationMessage { get; }

    /// <summary>
    /// Initializes a new instance of the ValidationResult class.
    /// </summary>
    /// <param name="validationType">The type of the validation attribute.</param>
    /// <param name="validationMessage">The validation error message.</param>
    public ValidationResult(Type validationType, string validationMessage)
    {
        this.ValidationType = validationType;
        this.ValidationMessage = validationMessage;
    }
}
