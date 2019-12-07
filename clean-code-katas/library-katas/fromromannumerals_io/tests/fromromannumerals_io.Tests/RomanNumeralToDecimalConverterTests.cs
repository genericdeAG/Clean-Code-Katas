namespace fromromannumerals_io.Tests
{
    using core;
    using FluentAssertions;
    using Xunit;

    public class RomanNumeralToDecimalConverterTests
    {
        [Theory]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("IX", 9)]
        public void ConvertToDecimaNumber_Should_ConvertRomanNumeral_ToItsDecimalEquivalent(string romanNumeral, int decimalNumber)
        {
            var result = RomanNumeralToDecimalConverter.ConvertToDecimalNumber(romanNumeral);
            result.Should().Be(decimalNumber);
        }
    }
}
