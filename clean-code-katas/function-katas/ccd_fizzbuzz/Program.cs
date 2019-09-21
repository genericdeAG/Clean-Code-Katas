using System.Linq;

namespace FizzBuzz
{
    public static class Program
    {
        public static void Main()
        {
            var numbers = NumbersGenerator.GenerateNumbers();
            var fizzBuzzes = numbers.Select(FizzBuzzer.GetFizzBuzzString);
            Presentation.DisplayTexts(fizzBuzzes);
        }
    }
}
