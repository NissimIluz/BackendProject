using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace Player
{
    public abstract class Player : IPlayer
    {
        XorO _identity;
        int _lastRow;
        int _lastCol;
        public Player(XorO identity)
        {
            _identity = identity;
        }
        public abstract bool makeMove(IXOBoard xOBoard);
        public abstract bool makeMove(IXOBoard xOBoard,XorO xoro);
        public XorO Identity { get; set; }
        public int LastCol { get; }
        public int LastRow { get; }
    }
}