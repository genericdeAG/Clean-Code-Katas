using System;

namespace extension_fizzbuzz.tests
{
    using System.Linq;
    using fizzbuzz;
    using FluentAssertions;
    using Xunit;

    public class ExtensionTests
    {
        private readonly string[] _fizzBuzzTexts = new[]
        {
            "FizzBuzz", "1", "2", "Fizz", "4", "Buzz",
            "Fizz", "7", "8", "Fizz", "Buzz"
        };

        private readonly int[] _numbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Fact]
        public void Should_GenerateNumbers()
        {
            // Act.
            var actual = Program.GenerateNumbers(0, 11);

            // Assert.
            actual.Should().BeEquivalentTo(_numbers);
        }

        [Fact]
        public void Should_ConvertNumbersToFizzBuzzTexts()
        {
           // Act.
            var actual = _numbers.ConvertToFizzBuzzTexts();

            // Assert.
            actual.Should().BeEquivalentTo(_fizzBuzzTexts);
        }


        [Fact]
        public void Should_DisplayFizzBuzzTexts()
        {
            // Arrange.
            var expected = string.Join(",\n", _fizzBuzzTexts);

            // Act.
            var actual = string.Empty;
            _fizzBuzzTexts.DisplayTexts((t) => actual = t);

            // Assert.
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
