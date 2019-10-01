namespace contracts
{
    using Dtos;

    public interface IWriteToFile
    {
        void Write(FileDto content);
    }
}