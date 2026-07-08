using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.exe
{
    internal class Duplicatewalletexception : Exception
    {
        public Duplicatewalletexception(string message) : base(message)
        {
        }
    }
}
