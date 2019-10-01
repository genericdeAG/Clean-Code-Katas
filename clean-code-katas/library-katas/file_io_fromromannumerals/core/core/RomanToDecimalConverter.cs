namespace core
{
    using System.Collections.Generic;
    using System.Linq;

    public static class RomanToDecimalConverter
    {
        private static readonly Dictionary<char, int> Numbers = new Dictionary<char, int>
        {
            { 'I',1 },
            { 'V',5 },
            { 'X',10 },
            { 'L',50 },
            { 'C',100 },
            { 'D',500 },
            { 'M',1000 }
        };

        private static IEnumerable<int> MapRomanDigitsToDecimalDigits(string romanNumber)
        {
            return romanNumber.Select((c) => Numbers[c]);
        }

        private static IEnumerable<int> SignNumbers(IEnumerable<int> decimalDigits)
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

        private static int SumNumbers(IEnumerable<int> signedDigits)
        {
            return signedDigits.Aggregate((a, b) => a + b);
        }

        public static int ConvertToDecimalNumber(string romanNumber)
        {
            var decimalDigits = MapRomanDigitsToDecimalDigits(romanNumber);
            var signedDigits = SignNumbers(decimalDigits);
            return SumNumbers(signedDigits);
        }
    }
}