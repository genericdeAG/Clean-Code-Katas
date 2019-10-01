namespace contracts
{
    using System.Collections.Generic;

    public interface IReadFromFile
    {
        IEnumerable<string> Read(string path);
    }
}