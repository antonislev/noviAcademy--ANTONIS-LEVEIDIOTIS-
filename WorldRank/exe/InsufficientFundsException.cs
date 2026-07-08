using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.exe
{
    internal class InsufficientFundsException : Exception
    {
        public
            InsufficientFundsException(string message) : base(message) { }
    }
}
