namespace contracts.Dtos
{
    public sealed class FileMetaDataDto
    {
        public string FileName { get; }

        public FileMetaDataDto(string fileName)
        {
            FileName = fileName;
        }
    }
}