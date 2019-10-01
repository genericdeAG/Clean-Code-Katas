namespace providers
{
    using System.Collections.Generic;
    using contracts;

    public class FileService : IWriteToFile, IReadFromFile
    {
        public void Write(string content)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Read(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}