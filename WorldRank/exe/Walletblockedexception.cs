using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.exe
{
    internal class Walletblockedexception : Exception
    {
        public Walletblockedexception(string message) : base(message)
        {
        }
    }
}
