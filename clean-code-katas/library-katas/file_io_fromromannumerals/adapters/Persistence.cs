namespace providers
{
    using System.IO;
    using contracts;
    using contracts.Dtos;

    public sealed class Persistence : IFileSystemAdapter
    {
        public FileDto Read(string path)
        {
            var content = File.ReadAllLines(path);
            return FileDto.Create(content);
        }

        public void Write(FileDto dto)
        {
            File.AppendAllLines(dto.MetaDataDto.FileName, dto.Content);
        }
    }
}