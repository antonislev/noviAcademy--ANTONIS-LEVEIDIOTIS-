using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.exe
{
    internal class WalletException : Exception
    {
        public
           WalletException(string message) : base(message)
        {
        }
    }
}
