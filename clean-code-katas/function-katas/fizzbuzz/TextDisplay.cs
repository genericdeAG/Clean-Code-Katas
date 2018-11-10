using System;
using System.Collections.Generic;

namespace fizzbuzz
{
    internal class TextDisplay
    {
        public void DisplayTexts(List<string> texts, Action<string> displayAction)
        {
            var output = string.Join(",", texts);

            displayAction(output);
        }
    }
}