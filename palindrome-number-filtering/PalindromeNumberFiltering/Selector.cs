using System.Collections.Concurrent;

namespace PalindromeNumberFiltering
{
    public static class Selector
    {
        public static IList<int> GetPalindromeInSequence(IList<int>? numbers)
        {
            ArgumentNullException.ThrowIfNull(numbers);

            var result = new List<int>();
            foreach (int n in numbers)
            {
                if (IsPalindrome(n))
                {
                    result.Add(n);
                }
            }

            return result;
        }

        public static IList<int> GetPalindromeInParallel(IList<int> numbers)
        {
            ArgumentNullException.ThrowIfNull(numbers);

            var bag = new ConcurrentBag<int>();
            Parallel.ForEach(numbers, n =>
            {
                if (IsPalindrome(n))
                {
                    bag.Add(n);
                }
            });

            return bag.ToList();
        }

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

            int length = GetLength(number);
            int divider = 1;
            for (int i = 1; i < length; i++)
            {
                divider *= 10;
            }

            return IsPositiveNumberPalindrome(number, divider);
        }

        private static bool IsPositiveNumberPalindrome(int number, int divider)
        {
            if (number < 10)
            {
                return true;
            }

            int firstDigit = number / divider;
            int lastDigit = number % 10;

            if (firstDigit != lastDigit)
            {
                return false;
            }

            int stripped = (number % divider) / 10;
            return IsPositiveNumberPalindrome(stripped, divider / 100);
        }

        private static byte GetLength(int number) => number switch
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
