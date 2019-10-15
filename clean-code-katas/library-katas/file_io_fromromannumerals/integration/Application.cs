namespace integration
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using contracts;
    using contracts.Dtos;
    using core;

    public sealed class Application
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
            var outputPath = CreateOutputPath(filePath);
            SaveOutput(output, outputPath);

            display(output);
        }

        private static string CreateOutputPath(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            return Path.Combine(directory, "decimalNumbers.txt");
        }

        private IEnumerable<int> ConvertToDecimal(IEnumerable<string> romanNumerals)
        {
            return romanNumerals.Select(RomanToDecimalConverter.ConvertToDecimalNumber);
        }

        private string FormatOutput(IEnumerable<int> decimalNumbers)
        {
            return string.Join(", ", decimalNumbers.Select(n => n.ToString()));
        }

        private void SaveOutput(string content, string filePath)
        {
            var decimalNumbers = content.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var fileMetaData = new FileMetaDataDto(filePath);
            var file = FileDto.WithMetaData(decimalNumbers, fileMetaData);
            _persistence.Write(file);
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
