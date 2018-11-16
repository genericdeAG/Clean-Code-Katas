using System;
using System.Collections.Generic;
using System.Linq;

namespace todictionary
{
    internal class ConfigToDictionaryConverter
    {
        internal IEnumerable<string> SplitIntoSettings(string configuration)
        {
            var delimiters = new[] { ";" };
            var settings = configuration.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return settings;
        }

        internal IEnumerable<(string, string)> SplitIntoKeyValuePairs(IEnumerable<string> settings)
        {
            var keyValues = settings.Select(s => (s.Split('=')));
            return keyValues.Select(kv => (kv[0], kv[1]));
        }

        internal Dictionary<string, string> WriteToDictionary(IEnumerable<(string,string)> keyValuePairs)
        {
            return keyValuePairs.ToDictionary(kv => kv.Item1, kv => kv.Item2);
        }

        public Dictionary<string, string> ToDictionary(string csv)
        {
            var settings = SplitIntoSettings(csv);
            var keyValuePairs = SplitIntoKeyValuePairs(settings);
            return WriteToDictionary(keyValuePairs);
        }
    }
}