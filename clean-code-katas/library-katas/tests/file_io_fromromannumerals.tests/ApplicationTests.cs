namespace file_io_fromromannumerals.tests
{
    using System.Linq;
    using contracts;
    using contracts.Dtos;
    using integration;
    using NSubstitute;
    using NSubstitute.ReceivedExtensions;
    using Xunit;

    [Trait("Category","Integration")]
    public class ApplicationTests
    {
        private readonly IUserInterface _uiStub;
        private readonly IFileSystem _persistenceStub;
        private readonly ICommandLineInterface _cliStub;

        private readonly Application _target;
        private const string FilePath = @"romanNumerals.txt";

        public ApplicationTests()
        {
            _uiStub = Substitute.For<IUserInterface>();
            _persistenceStub = Substitute.For<IFileSystem>();
            _cliStub = Substitute.For<ICommandLineInterface>();

            _target = new Application(_persistenceStub, _uiStub, _cliStub);

            _persistenceStub.Read(Arg.Any<string>()).Returns(FileDto.Create(
                new[] { "MDLXXXII", "CLXXXIII", "LVIII", "MMXIV" }));
            _cliStub.GetFilePathFromParameters(Arg.Any<string[]>()).Returns(FilePath);
        }

        [Fact]
        public void AcceptanceTest()
        {
            var args = new[] { FilePath };

            const string expectedOutput = "1582, 183, 58, 2014";
            _target.Execute(args, _uiStub.DisplayMessage);
            _uiStub.Received(1).DisplayMessage(expectedOutput);
            _persistenceStub.Received(1).Write(Arg.Is<FileDto>(
                dto => dto.Content.Contains("1582")));
        }
    }
}