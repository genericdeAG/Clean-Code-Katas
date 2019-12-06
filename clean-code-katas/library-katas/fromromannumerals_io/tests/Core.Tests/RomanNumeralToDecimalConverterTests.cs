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

        [Theory]
        [InlineData(new[] {10}, 10)]
        [InlineData(new[] {10, 1}, 11)]
        [InlineData(new[] {-1, 10}, 9)]
        public void SumNumbers_Should_SummarizeAllPreSignedDigits_ToDecimalNumber(int[] signedDigits, int decimalNumber)
        {
            var result = RomanNumeralToDecimalConverter.SummarizeNumber(signedDigits);
            result.Should().Be(decimalNumber);
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
                var digits = unsignedDigits.ToArray();
                var signedDigits = new List<int>();

                for (var position = 0; position < digits.Count(); position++)
                {
                    if (NotLastDigit(position, digits) && SmallerNextThatNextDigit(digits, position))
                    {
                        signedDigits.Add(-digits[position]);
                    }
                    else
                    {
                        signedDigits.Add(+digits[position]);
                    }
                }

                return signedDigits;
            }

            private static bool SmallerNextThatNextDigit(int[] digits, int position)
            {
                return digits[position + 1] > digits[position];
            }

            private static bool NotLastDigit(int position, int[] digits)
            {
                return position + 1 < digits.Count();
            }

            internal static int SummarizeNumber(IEnumerable<int> signedDigits)
            {
                throw new NotImplementedException();
            }
        }
    }
}
