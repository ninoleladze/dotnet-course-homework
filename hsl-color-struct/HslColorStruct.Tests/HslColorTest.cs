using System;
using NUnit.Framework;

namespace HslColorStruct.Tests;

[TestFixture]
public class HslColorTests
{
    [Test]
    public void Constructor_WithValidValues_CreatesColor()
    {
        // Arrange
        int hue = 120;
        int saturation = 50;
        int lightness = 75;

        // Act
        var color = new HslColor(hue, saturation, lightness);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(color.Hue, Is.EqualTo(hue));
            Assert.That(color.Saturation, Is.EqualTo(saturation));
            Assert.That(color.Lightness, Is.EqualTo(lightness));
        });
    }

    [Test]
    public void TryParse_NullOrEmptyOrWhitespace_ReturnsFalse()
    {
        Assert.Multiple(() =>
        {
            Assert.That(HslColor.TryParse(null!, out _), Is.False);
            Assert.That(HslColor.TryParse(string.Empty, out _), Is.False);
            Assert.That(HslColor.TryParse("   ", out _), Is.False);
        });
    }

    [TestCase(" 0,0,0")]
    [TestCase("0,0,0 ")]
    [TestCase("0,0")]
    [TestCase("0,0,0,0")]
    [TestCase("a,b,c")]
    [TestCase("361,0,0")]
    [TestCase("-1,0,0")]
    [TestCase("0,101,0")]
    [TestCase("0,0,101")]
    public void TryParse_InvalidStrings_ReturnFalse(string input)
    {
        var result = HslColor.TryParse(input, out var color);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(color, Is.EqualTo(default(HslColor)));
        });
    }

    [TestCase(" 0,0,0")]
    [TestCase("0,0,0 ")]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("0,0")]
    [TestCase("a,b,c")]
    public void Parse_InvalidStrings_ThrowsArgumentException_Params(string input)
    {
        Assert.Throws<ArgumentException>(() => HslColor.Parse(input));
    }

    [Test]
    public void Create_WithInvalidValues_Throws()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => HslColor.Create(-1, 0, 0));
            Assert.Throws<ArgumentException>(() => HslColor.Create(0, -1, 0));
            Assert.Throws<ArgumentException>(() => HslColor.Create(0, 0, -1));
            Assert.Throws<ArgumentException>(() => HslColor.Create(361, 0, 0));
            Assert.Throws<ArgumentException>(() => HslColor.Create(0, 101, 0));
        });
    }

    [Test]
    public void ToString_ThenParse_Roundtrip()
    {
        var original = new HslColor(47, 88, 12);
        var s = original.ToString();
        var parsed = HslColor.Parse(s);
        Assert.That(parsed, Is.EqualTo(original));
    }

    [Test]
    public void Equals_ObjectNullAndDifferentType()
    {
        var a = new HslColor(1, 2, 3);
        Assert.Multiple(() =>
        {
            Assert.That(a.Equals((object?)null), Is.False);
            Assert.That(a.Equals("not a color"), Is.False);
        });
    }

    [Test]
    public void GetHashCode_DifferentValues_OftenDiffer()
    {
        var a = new HslColor(1, 2, 3);
        var b = new HslColor(2, 1, 3);
        Assert.That(a.GetHashCode(), Is.Not.EqualTo(b.GetHashCode()));
    }

    [TestCase("x,0,0")]
    [TestCase("0,y,0")]
    [TestCase("0,0,z")]
    public void TryParse_NonIntegerParts_ReturnsFalse(string input)
    {
        var ok = HslColor.TryParse(input, out var c);
        Assert.Multiple(() =>
        {
            Assert.That(ok, Is.False);
            Assert.That(c, Is.EqualTo(default(HslColor)));
        });
    }

    [Test]
    public void Parse_NonIntegerParts_Throws()
    {
        Assert.Throws<ArgumentException>(() => HslColor.Parse("x,0,0"));
        Assert.Throws<ArgumentException>(() => HslColor.Parse("0,y,0"));
        Assert.Throws<ArgumentException>(() => HslColor.Parse("0,0,z"));
    }

    [Test]
    public void Equality_WithBoxedValue_Works()
    {
        var a = new HslColor(5, 6, 7);
        object boxed = a;
        Assert.Multiple(() =>
        {
            Assert.That(a.Equals(boxed), Is.True);
            Assert.That(boxed.Equals(a), Is.True);
        });
    }

    [Test]
    public void TryParse_BoundaryValues_Succeeds()
    {
        Assert.Multiple(() =>
        {
            Assert.That(HslColor.TryParse("0,0,0", out var a), Is.True);
            Assert.That(a, Is.EqualTo(new HslColor(0,0,0)));
            Assert.That(HslColor.TryParse("360,100,100", out var b), Is.True);
            Assert.That(b, Is.EqualTo(new HslColor(360,100,100)));
        });
    }

    [Test]
    public void Constructor_WithInvalidHue_ThrowsArgumentException()
    {
        // Arrange
        int hue = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new HslColor(hue, 50, 50));
    }

    [Test]
    public void Create_WithValidValues_ReturnsSameAsConstructor()
    {
        // Arrange
        int hue = 360;
        int saturation = 100;
        int lightness = 0;

        // Act
        var a = new HslColor(hue, saturation, lightness);
        var b = HslColor.Create(hue, saturation, lightness);

        // Assert
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a.Hue, Is.EqualTo(hue));
    }

    [Test]
    public void Parse_WithValidString_ReturnsColor()
    {
        // Arrange
        string hslString = "120,50,75";

        // Act
        var color = HslColor.Parse(hslString);

        // Assert
        Assert.That(color.Hue, Is.EqualTo(120));
        Assert.That(color.Saturation, Is.EqualTo(50));
        Assert.That(color.Lightness, Is.EqualTo(75));
    }

    [Test]
    public void TryParse_WithValidString_ReturnsTrueAndSetsOut()
    {
        // Arrange
        string hslString = "0,0,0";

        // Act
        var ok = HslColor.TryParse(hslString, out var color);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(ok, Is.True);
            Assert.That(color.Hue, Is.EqualTo(0));
            Assert.That(color.Saturation, Is.EqualTo(0));
            Assert.That(color.Lightness, Is.EqualTo(0));
        });
    }

    [Test]
    public void Parse_WithInvalidString_ThrowsArgumentException()
    {
        // Arrange
        string invalid = "not,a,color";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => HslColor.Parse(invalid));
    }

    [Test]
    public void TryParse_WithInvalidString_ReturnsFalse()
    {
        // Arrange
        string invalid = "";

        // Act
        var ok = HslColor.TryParse(invalid, out var color);

        // Assert
        Assert.That(ok, Is.False);
        Assert.That(color, Is.EqualTo(default(HslColor)));
    }

    [Test]
    public void Equality_Operators_WorkAsExpected()
    {
        // Arrange
        var a = new HslColor(10, 20, 30);
        var b = new HslColor(10, 20, 30);
        var c = new HslColor(11, 20, 30);

        // Act & Assert
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a, Is.Not.EqualTo(c));
            Assert.That(a.Equals(b), Is.True);
            Assert.That(a.Equals(c), Is.False);
        });
    }

    [Test]
    public void GetHashCode_SameValues_ProduceSameHash()
    {
        // Arrange
        var a = new HslColor(1, 2, 3);
        var b = new HslColor(1, 2, 3);

        // Act
        var ha = a.GetHashCode();
        var hb = b.GetHashCode();

        // Assert
        Assert.That(ha, Is.EqualTo(hb));
    }

    [Test]
    public void ToString_FormatsAsCommaSeparatedIntegers()
    {
        // Arrange
        var a = new HslColor(123, 45, 67);

        // Act
        var s = a.ToString();

        // Assert
        Assert.That(s, Is.EqualTo("123,45,67"));
    }

    [Test]
    public void Parse_WithSpaces_ReturnsColor()
    {
        // Arrange
        string s = "240 , 100 , 50"; // internal spaces allowed, no leading/trailing

        // Act
        var ok = HslColor.TryParse(s, out var c);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(ok, Is.True);
            Assert.That(c.Hue, Is.EqualTo(240));
            Assert.That(c.Saturation, Is.EqualTo(100));
            Assert.That(c.Lightness, Is.EqualTo(50));
        });
    }

    [Test]
    public void Boundary_Values_AreAccepted()
    {
        // Arrange & Act
        var a = new HslColor(0, 0, 0);
        var b = new HslColor(360, 100, 100);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(a.Hue, Is.EqualTo(0));
            Assert.That(b.Hue, Is.EqualTo(360));
        });
    }
}
