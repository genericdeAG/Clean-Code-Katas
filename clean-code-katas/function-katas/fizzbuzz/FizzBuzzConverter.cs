using System;
using System.Collections.Generic;
using System.Linq;

namespace fizzbuzz
{
    internal class FizzBuzzConverter
    {
        internal string ConvertToFizzBuzzText(int number)
        {
            if (IsNumberDivisibleByThree(number) && IsNumberDivisibleByFive(number)) return "FizzBuzz";
            if (IsNumberDivisibleByThree(number)) return "Fizz";
            if (IsNumberDivisibleByFive(number)) return "Buzz";

            return Convert.ToString(number);
        }

        private bool IsNumberDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }

        private bool IsNumberDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }

        public IEnumerable<string> ConvertToFizzBuzzTexts(IEnumerable<int> numbers)
        {
            return numbers.Select(n => ConvertToFizzBuzzText(n));
        }
    }
}