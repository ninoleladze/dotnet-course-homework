namespace ValidationAttributes;

/// <summary>
/// Specifies the minimum and maximum length of characters that are allowed in a data field.
/// </summary>
#pragma warning disable CA1813 // Avoid unsealed attributes
public class StringLengthAttribute : ValidationAttribute
#pragma warning restore CA1813
{
    /// <summary>
    /// Initializes a new instance of the StringLengthAttribute class with minimum and maximum lengths.
    /// </summary>
    /// <param name="minimumLength">The minimum allowed length of the string.</param>
    /// <param name="maximumLength">The maximum allowed length of the string.</param>
    public StringLengthAttribute(int minimumLength, int maximumLength)
        : base("The string length must be greater than or equal " + minimumLength + " and less than or equal " + maximumLength + ".")
    {
        this.MinimumLength = minimumLength;
        this.MaximumLength = maximumLength;
    }

    /// <summary>
    /// Initializes a new instance of the StringLengthAttribute class with minimum, maximum lengths, and a custom error message.
    /// </summary>
    /// <param name="minimumLength">The minimum allowed length of the string.</param>
    /// <param name="maximumLength">The maximum allowed length of the string.</param>
    /// <param name="errorMessage">The error message to display if validation fails.</param>
    public StringLengthAttribute(int minimumLength, int maximumLength, string errorMessage)
        : base(errorMessage)
    {
        this.MinimumLength = minimumLength;
        this.MaximumLength = maximumLength;
    }

    /// <summary>
    /// Gets the minimum allowed length of the string.
    /// </summary>
    public int MinimumLength { get; }

    /// <summary>
    /// Gets the maximum allowed length of the string.
    /// </summary>
    public int MaximumLength { get; }

    /// <summary>
    /// Determines whether the specified value is a valid string length.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>true if the value is null or a string with length between MinimumLength and MaximumLength; otherwise, false.</returns>
    public override bool IsValid(object? value)
    {
        // Null values are considered valid for StringLength (but invalid for Required)
        if (value == null)
        {
            return true;
        }

        // Only validate strings
        if (value is not string str)
        {
            return false;
        }

        // Validate the length
        return str.Length >= this.MinimumLength && str.Length <= this.MaximumLength;
    }
}
