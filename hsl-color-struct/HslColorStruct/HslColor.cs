using System;

namespace HslColorStruct;

/// <summary>
/// Represents a color in the HSL color model.
/// </summary>
    /// <summary>
    /// Struct representing Hue, Saturation, and Lightness components.
    /// </summary>
    public readonly struct HslColor : IEquatable<HslColor>
{
    /// <summary>
    /// Hue component (0-360).
    /// </summary>
    public int Hue { get; init; }

    /// <summary>
    /// Saturation component (0-100).
    /// </summary>
    public int Saturation { get; init; }

    /// <summary>
    /// Lightness component (0-100).
    /// </summary>
    public int Lightness { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HslColor"/> struct with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    /// <exception cref="ArgumentException">Thrown when any of the components is outside its valid range.</exception>
    public HslColor(int hue, int saturation, int lightness)
    {
        ThrowExceptionIfValueIsNotValid(hue, nameof(hue), 0, 360);
        ThrowExceptionIfValueIsNotValid(saturation, nameof(saturation), 0, 100);
        ThrowExceptionIfValueIsNotValid(lightness, nameof(lightness), 0, 100);

        this.Hue = hue;
        this.Saturation = saturation;
        this.Lightness = lightness;
    }

    /// <summary>
    /// Gets the hue component (0-360 degrees).
    /// </summary>
    // Auto-properties declared above

    /// <summary>
    /// Creates a new instance of the <see cref="HslColor"/> struct with specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    /// <returns>A <see cref="HslColor"/> that is initialized with specified components.</returns>
    /// <exception cref="ArgumentException">Thrown when any of the components is outside its valid range.</exception>
    public static HslColor Create(int hue, int saturation, int lightness)
        => new HslColor(hue, saturation, lightness);

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <returns>An <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hslString"/> is invalid.</exception>
    public static HslColor Parse(string hslString)
    {
        if (!TryParse(hslString, out var result))
        {
            throw new ArgumentException("Input string is not a valid HSL color in format \"H,S,L\".", nameof(hslString));
        }

        return result;
    }

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent. A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <param name="hslColor">A <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</param>
    /// <returns>true if <paramref name="hslString"/> was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string hslString, out HslColor hslColor)
    {
        hslColor = default;

        if (string.IsNullOrWhiteSpace(hslString))
        {
            return false;
        }

        // Reject strings with leading or trailing whitespace
        if (!string.Equals(hslString, hslString.Trim(), StringComparison.Ordinal))
        {
            return false;
        }

        var parts = hslString.Split(',');
        if (parts.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(parts[0].Trim(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var hue))
        {
            return false;
        }

        if (!int.TryParse(parts[1].Trim(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var saturation))
        {
            return false;
        }

        if (!int.TryParse(parts[2].Trim(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var lightness))
        {
            return false;
        }

        if (hue < 0 || hue > 360 || saturation < 0 || saturation > 100 || lightness < 0 || lightness > 100)
        {
            return false;
        }

        hslColor = new HslColor(hue, saturation, lightness);
        return true;
    }

    /// <summary>
    /// Determines whether the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="other">The <see cref="HslColor"/> to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public bool Equals(HslColor other)
        => this.Hue == other.Hue && this.Saturation == other.Saturation && this.Lightness == other.Lightness;

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="obj">The object to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified object is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public override bool Equals(object? obj)
        => obj is HslColor other && Equals(other);

    /// <summary>
    /// Gets a hash code of the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A hash code of the current <see cref="HslColor"/>.</returns>
    public override int GetHashCode()
        => HashCode.Combine(this.Hue, this.Saturation, this.Lightness);

    /// <summary>
    /// Returns a string that represents the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="HslColor"/>.</returns>
    public override string ToString()
        => $"{this.Hue},{this.Saturation},{this.Lightness}";

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator ==(HslColor left, HslColor right)
        => left.Equals(right);

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator !=(HslColor left, HslColor right)
        => !left.Equals(right);

    private static void ThrowExceptionIfValueIsNotValid(int value, string parameterName, int minValue, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentException($"{parameterName} must be in range [{minValue}..{maxValue}].", parameterName);
        }
    }
}
