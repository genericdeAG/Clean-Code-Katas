namespace contracts
{
    using System.Collections.Generic;
    using Dtos;

    public interface IReadFromFile
    {
        FileDto Read(string path);
    }
}