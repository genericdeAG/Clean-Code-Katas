using System;
using System.Collections.Generic;
using System.Text;

namespace fromromannumerals_io.Tests
{
    using contracts;
    using FluentAssertions;
    using Xunit;

    public class PersistenceAdapterTests
    {
        private readonly IPersistence _persistence;

        public PersistenceAdapterTests()
        {
            _persistence = new PersistenceAdapter();
        }

        [Fact]
        public void GetRomanNumerals_Should_RetrieveRomanNumerals_FromGivenFilePath()
        {
            var expected = new[] { "MMMCMXCIX", "CCCXXX", "DCCCLXXX", "D", "MCMXCIV" };
            var filePath = @"C:\SRC\Clean-Code-Katas\clean-code-katas\library-katas\fromromannumerals_io\tests\fromromannumerals_io.Tests\files\romannumerals.txt";
            var actual = _persistence.GetRomanNumerals(filePath);
            actual.Should().BeEquivalentTo(expected);
        }
    }

    public class PersistenceAdapter : IPersistence
    {
        public IEnumerable<string> GetRomanNumerals(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SaveResult(IEnumerable<int> decimalNumbers)
        {
            throw new NotImplementedException();
        }
    }
}
