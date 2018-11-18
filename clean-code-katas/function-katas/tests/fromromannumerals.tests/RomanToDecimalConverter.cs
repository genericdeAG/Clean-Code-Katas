using System.Collections.Generic;
using System.Linq;

namespace fromromannumerals.tests
{
    internal class RomanToDecimalConverter
    {
        private readonly Dictionary<char, int> _numbers = new Dictionary<char, int>
        {
            { 'I',1 },
            { 'V',5 },
            { 'X',10 },
            { 'L',50 },
            { 'C',100 },
            { 'D',500 },
            { 'M',1000 }
        };

        internal IEnumerable<int> MapRomanDigitsToDecimalDigits(string romanNumber)
        {
            return romanNumber.Select((c) => _numbers[c]);
        }

        internal IEnumerable<int> SignNumbers(IEnumerable<int> decimalDigits)
        {
            var digits = decimalDigits.ToArray();
            var signedDigits = new List<int>();

            for (var position = 0; position < digits.Count(); position++)
            {
                if (NotLastDigit(position, digits) && SmallerNextThatNextDigit(digits, position))
                {
                    signedDigits.Add(-digits[position]);
                }
                else
                {
                    signedDigits.Add(+digits[position]);
                }
            }

            return signedDigits;
        }

        private static bool SmallerNextThatNextDigit(int[] digits, int position)
        {
            return digits[position + 1] > digits[position];
        }

        private static bool NotLastDigit(int position, int[] digits)
        {
            return position + 1 < digits.Count();
        }

        internal int SumNumbers(IEnumerable<int> signedDigits)
        {
            return signedDigits.Aggregate((a, b) => a + b);
        }

        public int ConvertToDecimalNumber(string romanNumber)
        {
            var decimalDigits = MapRomanDigitsToDecimalDigits(romanNumber);
            var signedDigits = SignNumbers(decimalDigits);
            return SumNumbers(signedDigits);
        }
    }
}