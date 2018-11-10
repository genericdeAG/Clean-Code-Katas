using System;
using FluentAssertions;
using Xunit;

namespace fizzbuzz.tests
{
    public class FizzBuzzConverterTests
    {
        private readonly FizzBuzzConverter _target;
        public FizzBuzzConverterTests()
        {
            _target = new FizzBuzzConverter();
        }

        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        public void ConvertToFizzBuzzText_GivenNumber_ShouldReturnFizzBuzzText(int number, string fizzBuzzText)
        {
            var actual = _target.ConvertToFizzBuzzText(number);

            fizzBuzzText.Should().Be(actual);
        }
    }

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
    }
}