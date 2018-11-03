using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void SplitIntoKeyValuePairs_GivenSettings_ShouldReturnKeyValuePairs()
        {
            var settings = new[] {"a=1", "b=2", "c=3", "d=4"};
            var expected = new[] {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4")};

            var actual = _target.SplitIntoKeyValuePairs(settings);

            actual.Should().BeEquivalentTo(expected);
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

    internal class ConfigToDictionaryConverter
    {
        public IEnumerable SplitIntoSettings(string configuration)
        {
            var delimiters = new string[] { ";" };
            var settings = configuration.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return settings;
        }

        internal IEnumerable<Tuple<string, string>> SplitIntoKeyValuePairs(string[] settings)
        {
            var keyValues = settings.Select(s => (s.Split('=')));
            return keyValues.Select(kv => Tuple.Create(kv[0], kv[1]));
        }

        public Dictionary<string, string> WriteToDictionary(IEnumerable<(string,string)> keyValuePairs)
        {
            throw new NotImplementedException();
        }
    }
}
