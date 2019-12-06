using System;
using Xunit;

namespace Core.Tests
{
    using System.Collections;
    using core;
    using FluentAssertions;

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
