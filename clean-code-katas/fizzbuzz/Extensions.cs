namespace fizzbuzz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Extensions
    {
        internal static IEnumerable<string> ConvertToFizzBuzzTexts(this IEnumerable<int> numbers)
        {
            return numbers.Select(ConvertToFizzBuzzText);
        }

        internal static void DisplayTexts(this IEnumerable<string> texts, Action<string> displayAction)
        {
            var output = string.Join(",\n", texts);

            displayAction(output);
        }

        private static string ConvertToFizzBuzzText(int number)
        {
            if (IsNumberDivisibleByThree(number) && IsNumberDivisibleByFive(number)) return "FizzBuzz";
            if (IsNumberDivisibleByThree(number)) return "Fizz";
            if (IsNumberDivisibleByFive(number)) return "Buzz";

            return Convert.ToString(number);
        }

        private static bool IsNumberDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }

        private static bool IsNumberDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }
    }
}