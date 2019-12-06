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
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("IX", 9)]
        public void ConvertToDecimaNumber_Should_ConvertRomanNumeral_ToItsDecimalEquivalent(string romanNumeral, int decimalNumber)
        {
            var result = RomanNumeralToDecimalConverter.ConvertToDecimalNumber(romanNumeral);
            result.Should().Be(decimalNumber);
        }

        public static class RomanNumeralToDecimalConverter
        {
            public static int ConvertToDecimalNumber(string romanNumeral)
            {
                var decimalDigits = ConvertToDecimalDigits(romanNumeral);
                var presignedDigits = PreSignDigits(decimalDigits);
                return SummarizeNumber(presignedDigits);
            }

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

            private static IEnumerable<int> ConvertToDecimalDigits(string romanNumeral)
            {
                return romanNumeral.Select(digit => RomanDecimalMapping[digit]);
            }

            private static IEnumerable<int> PreSignDigits(IEnumerable<int> unsignedDigits)
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

            private static int SummarizeNumber(IEnumerable<int> signedDigits)
            {
                return signedDigits.Aggregate((first, second) => first + second);
            }
        }
    }
}
