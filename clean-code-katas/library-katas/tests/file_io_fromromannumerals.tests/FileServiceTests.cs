using System;
using Xunit;

namespace file_io_fromromannumerals.tests
{
    using System.IO;
    using contracts;
    using contracts.Dtos;
    using FluentAssertions;
    using providers;

    [Trait("Category","File-System")]
    public class FileServiceTests
    {
        private const string InputTestFilePath = "input.txt";
        private const string OutputTestFilePath = "output.txt";
        private readonly string[] _inputContent = {"MDLXXXII", "CLXXXIII", "LVIII", "MMXIV"};
        private readonly string[] _outputContent = {"1582", "183", "58", "2014"};
        private readonly IFileService _target;

        public FileServiceTests()
        {
            _target = new FileService();
        }

        private void CreateInputFile()
        {
            File.WriteAllLines(InputTestFilePath, _inputContent);
        }

        [Fact]
        public void Should_ReadFileContent_When_FileExists()
        {
            // Arrange.
            CreateInputFile();

            // Act.
            var content = _target.Read(InputTestFilePath).Content;

            // Assert.
            content.Should().BeEquivalentTo(_inputContent);

            File.Delete(InputTestFilePath);
        }

        [Fact]
        public void Should_WriteFileContent()
        {
            // Arrange.
            var metaData = new FileMetaDataDto(OutputTestFilePath);
            var dto = FileDto.WithMetaData(_outputContent, metaData);

            // Act.
            _target.Write(dto);
            var inserted = File.ReadAllLines(OutputTestFilePath);

            // Assert.
            inserted.Should().BeEquivalentTo(_outputContent);

            File.Delete(OutputTestFilePath);
        }
    }
}
