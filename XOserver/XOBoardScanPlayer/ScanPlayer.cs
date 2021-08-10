using InfraAttributes;
using Contracts;
using System;

namespace XOBoardScanPlayer
{
    [Register(typeof(IScanPlayer))]
    [Policy(Policy.Transient)]
    public class ScanPlayer : Player, IScanPlayer
    {   //initialization the values allows the code to be faster
        public ScanPlayer(XorO identity = XorO.X)
            : base(identity) { }

        public override bool makeMove(IXOBoard xOBoard)
        {
            bool retval = true;
            while (retval && !xOBoard.Put(Identity, LastRow, LastCol))
            {
                if (_lastCol < xOBoard.Size)
                    _lastCol++;
                else
                {
                    if (_lastRow < xOBoard.Size)
                    {
                        _lastRow++;
                        _lastCol = 0;
                    }
                    else
                    {
                        retval = false;
                    }
                }
            }
            return retval;
        }

        public static Type InterfaceType()
        {
            throw new NotImplementedException();
        }
    }
}