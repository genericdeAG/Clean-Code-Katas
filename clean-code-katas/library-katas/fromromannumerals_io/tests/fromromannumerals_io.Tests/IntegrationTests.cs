namespace fromromannumerals_io.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using contracts;
    using core;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class IntegrationTests
    {
        private readonly IPersistence _persistence;
        private readonly IUserInterface _ui;
        private readonly ICommandLineInterface _cli;
        private readonly Application _target;
        private readonly IEnumerable<string> _dummyRomanNumerals = new[] {"X", "XI", "IX"};
        private readonly IEnumerable<int> _dummyDecimalNumbers = new[] {10, 11, 9};
        private const string InputFilePath = @"C:\SRC\Clean-Code-Katas\clean-code-katas\library-katas\fromromannumerals_io\tests\fromromannumerals_io.Tests\files\romannumerals.txt";
        private const string OutputFilePath = @"C:\SRC\Clean-Code-Katas\clean-code-katas\library-katas\fromromannumerals_io\tests\fromromannumerals_io.Tests\files\decimalNumbers.txt";

        public IntegrationTests()
        {
            _persistence = Substitute.For<IPersistence>();
            _ui = Substitute.For<IUserInterface>();
            _cli = Substitute.For<ICommandLineInterface>();

            _persistence.GetRomanNumerals(InputFilePath).Returns(_dummyRomanNumerals);
            _cli.GetFilePathFromParameters(Arg.Any<string[]>()).Returns(InputFilePath);
            _persistence.SaveResult(OutputFilePath, _dummyDecimalNumbers);
            _ui.ShowResult(_dummyDecimalNumbers);

        }
    }

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

    }
}
