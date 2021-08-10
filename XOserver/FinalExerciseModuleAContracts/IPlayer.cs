using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPlayer
    {
        bool makeMove(IXOBoard board);
        XorO Identity { get; set; }
        int LastCol { get; }
        int LastRow { get; }
    }

}
