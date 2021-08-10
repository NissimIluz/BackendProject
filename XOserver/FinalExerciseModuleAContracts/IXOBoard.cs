using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public enum XorO { Empty = 0, X = 1, O = -1 }
    public enum Status { None, Draw, X, O }
    public interface IXOBoard
    {
        bool Put(XorO xoro, int row, int col);
        XorO getCell(int row, int col);

        Status getStatus();
        int Size { get; }


    }
}
