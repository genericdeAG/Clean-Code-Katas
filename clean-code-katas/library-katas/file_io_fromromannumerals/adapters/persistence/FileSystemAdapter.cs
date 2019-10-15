namespace adapters.persistence
{
    using System.IO;
    using contracts;
    using contracts.Dtos;

    public sealed class FileSystemAdapter : IFileSystem
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
