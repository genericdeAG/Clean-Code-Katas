using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public static class NumbersGenerator
    {
        public static IEnumerable<int> GenerateNumbers()
        {
            return Enumerable.Range(1, 100);
        }
    }
}