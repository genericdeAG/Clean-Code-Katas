namespace FizzBuzz
{
    public static class FizzBuzzer
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = Fizz + Buzz;

        public static string GetFizzBuzzString(int number)
        {
            var isFizz = IsFizz(number);
            var isBuzz = IsBuzz(number);
            var isFizzBuzz = IsFizzBuzz(number);

            if (isFizzBuzz)
            {
                return FizzBuzz;
            }

            if (isFizz)
            {
                return Fizz;
            }

            if (isBuzz)
            {
                return Buzz;
            }

            return number.ToString();
        }

        private static bool IsFizzBuzz(int number)
        {
            return IsFizz(number) && IsBuzz(number);
        }

        private static bool IsBuzz(int number)
        {
            return number % 5 == 0;
        }

        private static bool IsFizz(int number)
        {
            return number % 3 == 0;
        }
    }
}