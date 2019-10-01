namespace contracts.Dtos
{
    using System.Collections.Generic;

    public sealed class FileDto
    {
        public IEnumerable<string> Content { get; }
        public FileMetaDataDto MetaDataDto { get; }

        private FileDto(IEnumerable<string> content, FileMetaDataDto metaDataDto) : this(content)
        {
            MetaDataDto = metaDataDto;
        }
        private FileDto(IEnumerable<string> content)
        {
            Content = content;
        }

        public static FileDto Create(IEnumerable<string> content)
        {
            return new FileDto(content);
        }

        public static FileDto WithMetaData(IEnumerable<string> content, FileMetaDataDto metaDataDto)
        {
            return new FileDto(content, metaDataDto);
        }
    }
}