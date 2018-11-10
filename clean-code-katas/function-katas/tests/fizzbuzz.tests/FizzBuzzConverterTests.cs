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

        [Fact]
        public void ConvertToFizzBuzzTexts_GivenNumbers_ShouldReturnFizzBuzzTexts()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 14, 15, 16 };
            var expected = new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "14", "FizzBuzz", "16" };

            var actual = _target.ConvertToFizzBuzzTexts(numbers);

            expected.Should().BeEquivalentTo(actual);
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
}