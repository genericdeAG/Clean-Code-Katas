namespace providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using contracts;
    using contracts.Dtos;

    public class FileService : IFileService
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