using System;
using System.Collections.Generic;
using System.Text;

namespace file_io_fromromannumerals.tests
{
    using core;
    using FluentAssertions;
    using Xunit;

    public class RomanToDecimalConverterTests
    {
        [Theory]
        [InlineData("IV", 4)]
        [InlineData("XXVI", 26)]
        [InlineData("MDC", 1600)]
        [InlineData("L", 50)]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("VII", 7)]
        public void Should_ConvertToDecimalNumber_Given_ValidRomanNumeral(string romanNumeral, int expectedDecimalNumber)
        {
            var actual = RomanToDecimalConverter.ConvertToDecimalNumber(romanNumeral);

            expectedDecimalNumber.Should().Be(actual);
        }
    }
}
