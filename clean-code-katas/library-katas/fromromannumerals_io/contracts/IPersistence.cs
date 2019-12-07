﻿using System;
using System.Collections.Generic;
using System.Text;

namespace contracts
{
    public interface IPersistence
    {
        IEnumerable<string> GetRomanNumerals(string filePath);

        void SaveResult(string filePath, IEnumerable<int> decimalNumbers);
    }
}
