using System.Collections;
using FluentAssertions;
using Xunit;

namespace todictionary.tests
{
    public class ConfigToDictionaryConverterTests
    {
        private readonly ConfigToDictionaryConverter _target;

        public ConfigToDictionaryConverterTests()
        {
            _target = new ConfigToDictionaryConverter();
        }

        [Fact]
        public void SplitIntoSettings_GivenCsvConfig_ShouldReturnSettings()
        {
            var csv = "a=1;b=2;c=3;d=4;";
            var expected = new[] {"a=1", "b=2", "c=3", "d=4"};

            var result = _target.SplitIntoSettings(csv);

            result.Should().BeEquivalentTo(expected);
        }
    }

    internal class ConfigToDictionaryConverter
    {
        public IEnumerable SplitIntoSettings(string csv)
        {
            throw new System.NotImplementedException();
        }
    }
}
