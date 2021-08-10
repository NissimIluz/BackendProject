using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public abstract class Player : IPlayer
    {
        public XorO _identity;
        public int _lastRow;
        public int _lastCol;
        public Player(XorO identity)
        {
            _identity = identity;
        }
        public abstract bool makeMove(IXOBoard xOBoard);
        public XorO Identity { get { return _identity; } set { _identity = value; } }
        public int LastCol { get { return _lastCol; } }
        public int LastRow { get{ return _lastRow; } }
    }
}

