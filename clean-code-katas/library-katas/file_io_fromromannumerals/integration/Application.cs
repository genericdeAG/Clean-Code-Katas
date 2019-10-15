namespace integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using contracts;
    using core;

    public class Application
    {
        private readonly IFileSystem _persistence;
        private readonly IUserInterface _ui;
        private readonly ICommandLineInterface _cli;

        public Application(
            IFileSystem persistence,
            IUserInterface ui,
            ICommandLineInterface cli)
        {
            _persistence = persistence;
            _ui = ui;
            _cli = cli;
        }

        public void Execute(string[] args, Action<string> display)
        {
            var filePath = GetFilePath(args);
            var romanNumerals = GetRomanNumerals(filePath);
            var decimalNumbers = ConvertToDecimal(romanNumerals);
            var output = FormatOutput(decimalNumbers);

            display(output);
        }

        private IEnumerable<int> ConvertToDecimal(IEnumerable<string> romanNumerals)
        {
            return romanNumerals.Select(RomanToDecimalConverter.ConvertToDecimalNumber);
        }

        private string FormatOutput(IEnumerable<int> decimalNumbers)
        {
            return string.Join(", ", decimalNumbers.Select(n => n.ToString()));
        }

        private IEnumerable<string> GetRomanNumerals(string filePath)
        {
            var file = _persistence.Read(filePath);
            return file.Content;
        }

        private string GetFilePath(string[] args)
        {
            var name = _cli.GetFilePathFromParameters(args);
            if (NoFilePath(name)) { name = _ui.AskForFilePath(); }
            return name;
        }

        private static bool NoFilePath(string name)
        {
            return string.IsNullOrEmpty(name);
        }
    }
}
