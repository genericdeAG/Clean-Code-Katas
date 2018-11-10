using System.Collections.Generic;
using System.Linq;

namespace fizzbuzz
{
    internal class NumberGenerator
    {
        public IEnumerable<int> GenerateNumbers()
        {
            return Enumerable.Range(0, 100);
        }
    }
}