using System;

namespace fizzbuzz
{
    internal class FizzBuzz
    {
        private readonly NumberGenerator _numberGenerator;
        private readonly FizzBuzzConverter _fizzBuzzConverter;
        private readonly TextDisplay _textDisplay;
        private readonly Action<string> _displayAction;
        public string Output { get; set; }

        public FizzBuzz()
        {
            _numberGenerator = new NumberGenerator();
            _fizzBuzzConverter = new FizzBuzzConverter();
            _textDisplay = new TextDisplay();
            _displayAction = (t) => Output = t;

        }

        public void DoFizzBuzz()
        {
            var numbers = _numberGenerator.GenerateNumbers();
            var fizzBuzzTexts = _fizzBuzzConverter.ConvertToFizzBuzzTexts(numbers);
            _textDisplay.DisplayTexts(fizzBuzzTexts, _displayAction);
        }
    }
}