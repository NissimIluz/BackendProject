using System;
using System.Collections.Generic;
using System.Text;

namespace XOContracts
{
    public interface IPlayer
    {
        bool makeMove(IXOBoard board,XorO xoro);
        bool makeMove(IXOBoard board);
        XorO Identity { get; set; }
        int LastCol { get; }
        int LastRow { get; }
    }

}
