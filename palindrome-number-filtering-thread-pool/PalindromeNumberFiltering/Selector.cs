namespace PalindromeNumberFiltering;

/// <summary>
/// A static class containing methods for filtering palindrome numbers from a collection of integers.
/// </summary>
public static class Selector
{
    /// <summary>
    /// Retrieves a collection of palindrome numbers from the given list of integers using concurrent filtering.
    /// </summary>
    public static IList<int> GetPalindromes(IList<int> numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);

        var result = new System.Collections.Concurrent.ConcurrentBag<int>();
        using var countdown = new CountdownEvent(numbers.Count);

        foreach (var number in numbers)
        {
            int captured = number;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    if (IsPalindrome(captured))
                    {
                        result.Add(captured);
                    }
                }
                finally
                {
                    countdown.Signal();
                }
            });
        }

        countdown.Wait();
        return result.ToList();
    }

    /// <summary>
    /// Checks whether the given integer is a palindrome number.
    /// </summary>
    private static bool IsPalindrome(int number)
    {
        if (number < 0)
        {
            return false;
        }

        if (number < 10)
        {
            return true;
        }

        byte length = GetLength(number);
        return IsPositiveNumberPalindrome(number, length - 1, 0);
    }

    /// <summary>
    /// Recursively checks whether a positive number is a palindrome.
    /// </summary>
    /// <param name="number">The positive number to check.</param>
    /// <param name="left">The index of the leftmost digit (highest decimal place).</param>
    /// <param name="right">The index of the rightmost digit (lowest decimal place).</param>
    private static bool IsPositiveNumberPalindrome(int number, int left, int right)
    {
        if (left <= right)
        {
            return true;
        }

        int leftDigit = GetDigitInDecimalPlace(number, left);
        int rightDigit = GetDigitInDecimalPlace(number, right);

        if (leftDigit != rightDigit)
        {
            return false;
        }

        return IsPositiveNumberPalindrome(number, left - 1, right + 1);
    }

    /// <summary>
    /// Retrieves the digit at a specified decimal place in a given number.
    /// decimalPlace 0 = ones, 1 = tens, 2 = hundreds, etc.
    /// </summary>
    private static int GetDigitInDecimalPlace(int number, int decimalPlace)
    {
        int divisor = 1;
        for (int i = 0; i < decimalPlace; i++)
        {
            divisor *= 10;
        }

        return (number / divisor) % 10;
    }

    /// <summary>
    /// Gets the number of digits in the given integer using a switch statement.
    /// </summary>
    private static byte GetLength(int number)
    {
        return number switch
        {
            < 10 => 1,
            < 100 => 2,
            < 1_000 => 3,
            < 10_000 => 4,
            < 100_000 => 5,
            < 1_000_000 => 6,
            < 10_000_000 => 7,
            < 100_000_000 => 8,
            < 1_000_000_000 => 9,
            _ => 10,
        };
    }
}
