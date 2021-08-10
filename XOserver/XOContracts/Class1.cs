using System;
using System.Collections.Generic;
using System.Text;

namespace XOContracts
{
        public abstract class Player : IPlayer
        {
            XorO _identity;
            protected int _lastRow;
            protected int _lastCol;
        public Player(XorO identity)
            {
                _identity = identity;
            }
        public abstract bool makeMove(IXOBoard xOBoard, XorO xoro);
        public abstract bool makeMove(IXOBoard board);
        public XorO Identity { get { return _identity; } set { _identity = value; } }
        public int LastCol
        {
            get { return _lastCol; }
        }
        public int LastRow
        {
            get { return _lastRow; }
        }
    }
    
}

