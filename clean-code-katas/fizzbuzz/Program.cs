using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizzbuzz
{
    internal sealed class Program
    {
        internal static void Main(string[] args)
        {
            GenerateNumbers(0, 100).ConvertToFizzBuzzTexts().DisplayTexts((Console.WriteLine));
        }

        internal static IEnumerable<int> GenerateNumbers(int rangeStart, int count)
        {
            return Enumerable.Range(rangeStart, count);
        }
    }
}
