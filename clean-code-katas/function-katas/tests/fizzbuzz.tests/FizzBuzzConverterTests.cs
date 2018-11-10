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
            throw new System.NotImplementedException();
        }
    }
}