using System;
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

        [Theory]
        [InlineData(new[] { -1, +5 }, 4)]
        [InlineData(new[] { +10, +10, +5, +1 }, 26)]
        [InlineData(new[] { +1000, +500, +100 }, 1600)]
        [InlineData(new[] { +50 }, 50)]
        [InlineData(new[] { +1, +1, +1 }, 3)]
        [InlineData(new[] { +5, +1, +1 }, 7)]
        public void SumNumbers_GivenSignedDecimalDigits_ShouldReturnDecimalNumber(int[] signedDigits, int decimalNumber)
        {
            var actual = _target.SumNumbers(signedDigits);

            decimalNumber.Should().Be(actual);
        }

        [Theory]
        [InlineData("IV", 4)]
        [InlineData("XXVI", 26)]
        [InlineData("MDC", 1600)]
        [InlineData("L", 50)]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("VII", 7)]
        public void ConvertToDecimalNumber_GivenRomanNumber_ShouldReturnDecimalNumber(string romanNumber, int decimalNumber)
        {
            var actual = _target.ConvertToDecimalNumber(romanNumber);

            decimalNumber.Should().Be(actual);
        }
    }
}
