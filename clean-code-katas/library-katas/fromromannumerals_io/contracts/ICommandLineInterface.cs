using System;
using System.Collections.Generic;
using System.Text;

namespace contracts
{
    public interface ICommandLineInterface
    {
        string GetFilePathFromParameters(string[] args);
    }
}
