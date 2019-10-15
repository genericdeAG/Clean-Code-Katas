namespace file_io_fromromannumerals.tests
{
    using adapters.cli;
    using contracts;
    using FluentAssertions;
    using Xunit;

    [Trait("Category","CLI")]
    public class CommandLineInterfaceAdapterTests
    {
        private readonly ICommandLineInterface _target;
        public CommandLineInterfaceAdapterTests()
        {
            _target = new CommandLineInterfaceAdapter();
        }

        [Fact]
        public void Should_GetFilePathFromParameters_When_ParametersContainValue()
        {
            const string expectedPath = "testPath";
            var args = new[] {expectedPath};
            var extractedPath = _target.GetFilePathFromParameters(args);

            extractedPath.Should().Be(expectedPath);
        }
    }
}