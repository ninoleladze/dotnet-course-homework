using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ContiguousSubstrings.Tests
{
    [TestFixture]
    public class SequencesTests
    {
        private static readonly string[] ExpectedSingle = new[] { "1" };
        private static readonly string[] ExpectedWhole12345 = new[] { "12345" };
        private static readonly string[] ExpectedDigits9876 = new[] { "9", "8", "7", "6" };
        private static readonly string[] ExpectedLeadingZeros = new[] { "00", "01", "12", "23" };
        private static readonly string[] Expected12Len1 = new[] { "1", "2" };
        private static readonly string[] Expected35Len2 = new[] { "35" };
        private static readonly string[] Expected9142Len2 = new[] { "91", "14", "42" };
        private static readonly string[] Expected777777Len3 = new[] { "777", "777", "777", "777" };
        private static readonly string[] ExpectedLong8 = new[] { "91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243" };
        private static readonly string[] ExpectedZero = new[] { "0" };

        private static readonly object[] ValidInputCases = new object[]
        {
            new object[] { "12", 1, Expected12Len1 },
            new object[] { "35", 2, Expected35Len2 },
            new object[] { "9142", 2, Expected9142Len2 },
            new object[] { "777777", 3, Expected777777Len3 },
            new object[] { "918493904243", 5, ExpectedLong8 },
        };

        [Test]
        public void GetSubstrings_SingleDigit_ReturnsSingle()
        {
            var actual = Sequences.GetSubstrings("1", 1).ToList();
            Assert.That(actual, Is.EqualTo(ExpectedSingle));
        }

        [TestCaseSource(nameof(ValidInputCases))]
        public void GetSubstrings_ValidInputs_ReturnExpected(string numbers, int length, string[] expected)
        {
            var actual = Sequences.GetSubstrings(numbers, length).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetSubstrings_LengthEqualsStringLength_ReturnsWholeString()
        {
            var actual = Sequences.GetSubstrings("12345", 5).ToList();
            Assert.That(actual, Is.EqualTo(ExpectedWhole12345));
        }

        [Test]
        public void GetSubstrings_LengthOne_ReturnsCharacters()
        {
            var actual = Sequences.GetSubstrings("9876", 1).ToList();
            Assert.That(actual, Is.EqualTo(ExpectedDigits9876));
        }

        // Negative tests
        [TestCase(null, 1)]
        [TestCase("", 1)]
        [TestCase("   ", 1)]
        public void GetSubstrings_NullOrWhiteSpace_ThrowsArgumentException(string numbers, int length)
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(numbers, length));
        }

        [TestCase("123a", 1)]
        [TestCase("12 3", 2)]
        [TestCase("12.3", 2)]
        public void GetSubstrings_NonDigitCharacters_ThrowsArgumentException(string numbers, int length)
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(numbers, length));
        }

        [TestCase("12345", 6)]
        [TestCase("123", 4)]
        public void GetSubstrings_LengthGreaterThanInput_ThrowsArgumentException(string numbers, int length)
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(numbers, length));
        }

        [TestCase("12345", 0)]
        [TestCase("123", -1)]
        public void GetSubstrings_NonPositiveLength_ThrowsArgumentException(string numbers, int length)
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(numbers, length));
        }

        [Test]
        public void GetSubstrings_AllBranches_CoverageSmoke()
        {
            // combination: valid numeric with leading zeros
            var actual = Sequences.GetSubstrings("00123", 2).ToList();
            Assert.That(actual, Is.EqualTo(ExpectedLeadingZeros));

            // smallest window
            actual = Sequences.GetSubstrings("0", 1).ToList();
            Assert.That(actual, Is.EqualTo(ExpectedZero));
        }
    }
}
