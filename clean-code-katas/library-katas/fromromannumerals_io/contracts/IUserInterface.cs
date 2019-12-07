using System;
using System.Collections.Generic;
using System.Text;

namespace contracts
{
    public interface IUserInterface
    {
        void ShowResult(IEnumerable<int> decimalNumbers);
    }
}
