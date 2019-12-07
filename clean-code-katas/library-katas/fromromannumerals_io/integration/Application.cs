using System;

namespace integration
{
    using System.Linq;
    using contracts;
    using core;

    public class Application
    {
        private readonly IPersistence _persistence;
        private readonly IUserInterface _ui;
        private readonly ICommandLineInterface _cli;

        public Application(
            IPersistence persistence,
            IUserInterface ui,
            ICommandLineInterface cli)
        {
            _persistence = persistence;
            _ui = ui;
            _cli = cli;
        }

        public void Run(string[] args)
        {
            var filePath = _cli.GetFilePathFromParameters(args);
            var romanNumerals = _persistence.GetRomanNumerals(filePath);
            var decimalNumbers = romanNumerals.Select(RomanNumeralToDecimalConverter.ConvertToDecimalNumber).ToArray();
            _persistence.SaveResult(filePath, decimalNumbers);
            _ui.ShowResult(decimalNumbers);
        }
    }
}
