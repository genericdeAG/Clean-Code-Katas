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

        [Theory]
        [InlineData(new[] { 10 }, new[] { 10 })]
        [InlineData(new[] { 10, 1 }, new[] { 10, 1 })]
        [InlineData(new[] { 1, 10 }, new[] { -1, 10 })]
        public void PreSignDigits_Should_AddPlusOrMinusSign_ToDecimalDigits(int[] unsignedDigits, int[] preSignedDigits)
        {
            var result = RomanNumeralToDecimalConverter.PreSignDigits(unsignedDigits);
            result.Should().BeEquivalentTo(preSignedDigits);
        }

        public static class RomanNumeralToDecimalConverter
        {
            private static readonly Dictionary<char, int> RomanDecimalMapping = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            internal static IEnumerable<int> ConvertToDecimalDigits(string romanNumeral)
            {
                return romanNumeral.Select(digit => RomanDecimalMapping[digit]);
            }

            internal static IEnumerable<int> PreSignDigits(IEnumerable<int> unsignedDigits)
            {
                throw new NotImplementedException();
            }
        }
    }
}
