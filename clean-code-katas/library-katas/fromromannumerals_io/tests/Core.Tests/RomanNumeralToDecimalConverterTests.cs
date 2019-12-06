using System;
using Xunit;

namespace Core.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    public class RomanNumeralToDecimalConverterTests
    {
        [Theory]
        [InlineData("X", new[] { 10 })]
        [InlineData("XI", new[] { 10, 1 })]
        [InlineData("IX", new [] { 1, 10 })]
        public void ConvertToDecimalDigits_Should_ConvertListOfRomanNumerals_ToItsDecimalDigits(string romanNumeral, int[] decimalDigits)
        {
            var result = RomanNumeralToDecimalConverter.ConvertToDecimalDigits(romanNumeral);
            result.Should().BeEquivalentTo(decimalDigits);
        }

        public static class RomanNumeralToDecimalConverter
        {

            internal static IEnumerable<int> ConvertToDecimalDigits(string romanNumeral)
            {
                throw new NotImplementedException();
            }
        }
    }
}
