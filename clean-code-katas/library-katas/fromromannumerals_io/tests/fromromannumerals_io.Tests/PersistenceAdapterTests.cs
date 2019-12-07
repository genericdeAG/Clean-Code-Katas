using System;
using System.Collections.Generic;
using System.Text;

namespace fromromannumerals_io.Tests
{
    using System.IO;
    using System.Linq;
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

        [Fact]
        public void SaveResult_Should_SaveDecimalNumbers_ToGivenFilePath()
        {
            var decimalNumbers = new[] {3999, 550, 880, 500, 1994};
            var expected = new[] { "3999", "550", "880", "500", "1994" };
            var filePath = @"C:\SRC\Clean-Code-Katas\clean-code-katas\library-katas\fromromannumerals_io\tests\fromromannumerals_io.Tests\files\decimalNumbers.txt";
            _persistence.SaveResult(filePath, decimalNumbers);
            var actual = File.ReadAllLines(filePath);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SaveResult_Should_CreateFile_IfItNotExists()
        {
            var filePath = @"C:\SRC\Clean-Code-Katas\clean-code-katas\library-katas\fromromannumerals_io\tests\fromromannumerals_io.Tests\files\newFile.txt";
            File.Delete(filePath);
            var decimalNumbers = Enumerable.Empty<int>();
            _persistence.SaveResult(filePath, decimalNumbers);
            File.Exists(filePath).Should().BeTrue();
        }
    }

    public class PersistenceAdapter : IPersistence
    {
        public IEnumerable<string> GetRomanNumerals(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public void SaveResult(string filePath, IEnumerable<int> decimalNumbers)
        {
            var decimalNumberStrings = decimalNumbers.Select(d => d.ToString());
            File.WriteAllLines(filePath, decimalNumberStrings);
        }
    }
}
