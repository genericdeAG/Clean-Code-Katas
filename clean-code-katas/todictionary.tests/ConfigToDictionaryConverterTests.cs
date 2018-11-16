using System.Collections;
using System.Collections.Generic;
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
        public void ToDictionary_GivenConfigCsv_ShouldReturnDictionaryFilledWithTheConfiguration()
        {
            var csv = "a=1;b=2;c=3;d=4;";
            var expected = new Dictionary<string, string> { { "a", "1" }, { "b", "2" }, { "c", "3" }, { "d", "4" } };

            var actual = _target.ToDictionary(csv);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void SplitIntoSettings_GivenCsvConfig_ShouldReturnSettings()
        {
            var csv = "a=1;b=2;c=3;d=4;";
            var expected = new[] {"a=1", "b=2", "c=3", "d=4"};

            var actual = _target.SplitIntoSettings(csv);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void SplitIntoKeyValuePairs_GivenSettings_ShouldReturnKeyValuePairs()
        {
            var settings = new[] {"a=1", "b=2", "c=3", "d=4"};
            var expected = new[] {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4")};

            var actual = _target.SplitIntoKeyValuePairs(settings);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void WriteToDictionary_GivenKeyValuePairs_ShouldReturnFilledDictionary()
        {
            var keyValuePairs = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4") };
            var expected = new Dictionary<string, string> {{"a", "1"}, {"b", "2"}, {"c", "3"}, {"d", "4"}};

            var actual = _target.WriteToDictionary(keyValuePairs);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
