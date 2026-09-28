namespace ValidationAttributes;

/// <summary>
/// Specifies the numeric range constraints for the value of a data field.
/// </summary>
#pragma warning disable CA1813 // Avoid unsealed attributes
public class NumericRangeAttribute : ValidationAttribute
#pragma warning restore CA1813
{
    private readonly object minimum;
    private readonly object maximum;
    private readonly Type operandType;

    /// <summary>
    /// Gets the minimum allowed value.
    /// </summary>
    public object Minimum => this.minimum;

    /// <summary>
    /// Gets the maximum allowed value.
    /// </summary>
    public object Maximum => this.maximum;

    /// <summary>
    /// Gets the type of the numeric range (defaults to double if not specified).
    /// </summary>
    public Type OperandType => this.operandType;

    /// <summary>
    /// Initializes a new instance of the NumericRangeAttribute class with minimum and maximum values.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    public NumericRangeAttribute(object minimum, object maximum)
        : base("The field must be between " + minimum + " and " + maximum + ".")
    {
        if (minimum == null)
        {
            throw new ArgumentNullException(nameof(minimum));
        }

        this.minimum = minimum;
        this.maximum = maximum;
        this.operandType = minimum.GetType();
    }

    /// <summary>
    /// Initializes a new instance of the NumericRangeAttribute class with minimum, maximum values, and operand type.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    /// <param name="operandType">The type of the numeric range (e.g., typeof(decimal)).</param>
    public NumericRangeAttribute(object minimum, object maximum, Type operandType)
        : base("The field must be between " + minimum + " and " + maximum + ".")
    {
        if (minimum == null)
        {
            throw new ArgumentNullException(nameof(minimum));
        }

        this.minimum = minimum;
        this.maximum = maximum;
        this.operandType = operandType;
    }

    /// <summary>
    /// Initializes a new instance of the NumericRangeAttribute class with minimum, maximum values, and a custom error message.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    /// <param name="errorMessage">The error message to display if validation fails.</param>
    public NumericRangeAttribute(object minimum, object maximum, string errorMessage)
        : base(errorMessage)
    {
        if (minimum == null)
        {
            throw new ArgumentNullException(nameof(minimum));
        }

        this.minimum = minimum;
        this.maximum = maximum;
        this.operandType = minimum.GetType();
    }

    /// <summary>
    /// Initializes a new instance of the NumericRangeAttribute class with minimum, maximum values, operand type, and a custom error message.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    /// <param name="operandType">The type of the numeric range.</param>
    /// <param name="errorMessage">The error message to display if validation fails.</param>
    public NumericRangeAttribute(object minimum, object maximum, Type operandType, string errorMessage)
        : base(errorMessage)
    {
        if (minimum == null)
        {
            throw new ArgumentNullException(nameof(minimum));
        }

        this.minimum = minimum;
        this.maximum = maximum;
        this.operandType = operandType;
    }

    /// <summary>
    /// Determines whether the specified value is a valid numeric value within the range.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>true if the value is a valid numeric value within the range; otherwise, false.</returns>
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        // Validate that min < max (not min <= max)
        if (Compare(this.minimum, this.maximum) >= 0)
        {
            throw new ArgumentException("The minimum value must be less than the maximum value.");
        }

        // Get the type of the value being validated
        Type valueType = value.GetType();

        // Check if the value type matches one of the supported numeric types
        if (!IsNumericType(valueType))
        {
            return false;
        }

        // Convert the value to the operand type for comparison
        object convertedValue;
        try
        {
            convertedValue = Convert.ChangeType(value, this.operandType, System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (InvalidCastException)
        {
            return false;
        }

        // Compare value with minimum and maximum
        return Compare(convertedValue, this.minimum) >= 0 && Compare(convertedValue, this.maximum) <= 0;
    }

    /// <summary>
    /// Determines whether the specified type is a supported numeric type.
    /// </summary>
    private static bool IsNumericType(Type type)
    {
        return type == typeof(byte) ||
               type == typeof(sbyte) ||
               type == typeof(short) ||
               type == typeof(ushort) ||
               type == typeof(int) ||
               type == typeof(uint) ||
               type == typeof(long) ||
               type == typeof(ulong) ||
               type == typeof(float) ||
               type == typeof(double) ||
               type == typeof(decimal);
    }

    /// <summary>
    /// Compares two numeric values.
    /// </summary>
    private static int Compare(object left, object right)
    {
        if (left == null && right == null)
        {
            return 0;
        }

        if (left == null)
        {
            return -1;
        }

        if (right == null)
        {
            return 1;
        }

        // Convert both to decimal for comparison
        try
        {
            decimal leftDecimal = Convert.ToDecimal(left, System.Globalization.CultureInfo.InvariantCulture);
            decimal rightDecimal = Convert.ToDecimal(right, System.Globalization.CultureInfo.InvariantCulture);
            return leftDecimal.CompareTo(rightDecimal);
        }
        catch (InvalidCastException)
        {
            return 0;
        }
    }
}
