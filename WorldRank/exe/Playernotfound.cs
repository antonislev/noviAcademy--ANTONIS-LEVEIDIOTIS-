using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.exe
{
    internal class Playernotfound : Exception
    {
        public Playernotfound(string message) : base(message)
        {
        }
    }
}
