namespace fromromannumerals_io.Tests
{
    using System.Linq;
    using cli;
    using contracts;
    using FluentAssertions;
    using Xunit;

    public class CommandLineInterfaceAdapterTests
    {
        private readonly ICommandLineInterface _cli;

        public CommandLineInterfaceAdapterTests()
        {
            _cli = new CommandLineInterfaceAdapter();
        }

        [Fact]
        public void GetFilePathFromParameters_Should_RetrieveFilePath_Given_Arguments()
        {
            var expected = "testFilePath";
            var args = new[] { expected };
            var actual = _cli.GetFilePathFromParameters(args);
            actual.Should().Be(expected);
        }

        [Fact]
        public void GetFilePathFromParameters_Should_ReturnNull_Given_EmptyArguments()
        {
            var args = Enumerable.Empty<string>().ToArray();
            var actual = _cli.GetFilePathFromParameters(args);
            actual.Should().BeNull();
        }

        [Fact]
        public void GetFilePathFromParameters_Should_ReturnFirstArgument_Given_MultipleArguments()
        {
            var args = new[] {"foo", "bar"};
            var actual = _cli.GetFilePathFromParameters(args);
            actual.Should().Be("foo");
        }
    }
}
