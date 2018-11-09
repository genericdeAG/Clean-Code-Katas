﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [InlineData(new[] { 1, 5 }, new[] { -1, +5 })]
        [InlineData(new[] { 10, 10, 5, 1 }, new[] { +10, +10, +5, +1 })]
        [InlineData(new[] { 1000, 500, 100 }, new[] { +1000, +500, +100 })]
        [InlineData(new[] { 50 }, new[] { +50 })]
        [InlineData(new[] { 1, 1, 1 }, new[] { +1, +1, +1 })]
        [InlineData(new[] { 5, 1, 1 }, new[] { +5, +1, +1 })]
        public void SignNumbers_GivenDecimalDigits_ShouldReturnSignedDecimalDigits(int[] decimalDigits, int[] signedDecimalDigits)
        {
            var actual = _target.SignNumbers(decimalDigits);

            signedDecimalDigits.Should().BeEquivalentTo(actual);
        }
    }

    internal class RomanToDecimalConverter
    {
        private readonly Dictionary<char, int> _numbers = new Dictionary<char, int>
        {
            { 'I',1 },
            { 'V',5 },
            { 'X',10 },
            { 'L',50 },
            { 'C',100 },
            { 'D',500 },
            { 'M',1000 }
        };

        internal IEnumerable<int> MapRomanDigitsToDecimalDigits(string romanNumber)
        {
            return romanNumber.Select((c) => _numbers[c]);
        }

        internal IEnumerable<int> SignNumbers(IEnumerable<int> decimalDigits)
        {
            var signedDigits = new List<int>();
            var digits = decimalDigits.ToArray();

            for (int i = 0; i < digits.Count(); i++)
            {
                if (i + 1 < digits.Count() && digits[i + 1] > digits[i])
                {
                    signedDigits.Add(-digits[i]);
                }
                else
                {
                    signedDigits.Add(+digits[i]);
                }
            }

            return signedDigits;
        }
    }
}
