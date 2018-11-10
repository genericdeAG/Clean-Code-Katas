using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace fizzbuzz.tests
{
    public class NumberGeneratorTests
    {
        private readonly NumberGenerator _target;

        public NumberGeneratorTests()
        {
            _target = new NumberGenerator();
        }

        [Fact]
        public void GenerateNumbers_ShouldReturnNumbersFrom1To100()
        {
            var expected = Enumerable.Range(0, 100);

            var actual = _target.GenerateNumbers();

            expected.Should().BeEquivalentTo(actual);
        }
    }

    internal class NumberGenerator
    {
        public IEnumerable<int> GenerateNumbers()
        {
            throw new System.NotImplementedException();
        }
    }
}