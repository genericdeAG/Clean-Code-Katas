using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public static class Presentation
    {
        public static void DisplayTexts(IEnumerable<string> texts)
        {
            foreach (var text in texts)
            {
                DisplayText(text);
            }
        }

        private static void DisplayText(object item)
        {
            Console.WriteLine(item);
        }
    }
}