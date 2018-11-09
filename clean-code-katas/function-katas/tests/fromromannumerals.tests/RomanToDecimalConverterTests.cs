using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace fromromannumerals.tests
{
    public class RomanToDecimalConverterTests
    {
        private readonly RomanToDecimalConverter _target;

        public RomanToDecimalConverterTests()
        {
            _target = new RomanToDecimalConverter();
        }

        [Theory]
        [InlineData("IV", 1, 5)]
        [InlineData("XXVI", 10, 10, 5, 1)]
        [InlineData("MDC", 1000, 500, 100)]
        [InlineData("L", 50)]
        [InlineData("V", 5)]
        [InlineData("III", 1, 1, 1)]
        [InlineData("VII", 5, 1, 1)]
        public void MapRomanDigitsToDecimalDigits_GivenRomanNumber_ShouldReturnDecimalDigits(string romanNumber, params int[] decimalDigits)
        {
            var actual = _target.MapRomanDigitsToDecimalDigits(romanNumber);

            decimalDigits.Should().BeEquivalentTo(actual);
        }
    }

    internal class RomanToDecimalConverter
    {
        public IEnumerable<int> MapRomanDigitsToDecimalDigits(string romanNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
