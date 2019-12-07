namespace persistence
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using contracts;

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