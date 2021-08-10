using InfraAttributes;
using System;
using System.Collections.Generic;
using Contracts;

namespace XOboardRandomPlayer
{
    [Register(typeof(IRandomPlayer))]
    [Policy(Policy.Transient)]
    public class RandomPlayer : Player, IRandomPlayer
    {
        int range;
        Dictionary<int, int> cells;
        public RandomPlayer(XorO identity = XorO.X)
            : base(identity)
        {
            range = -1;
        }
        public override bool makeMove(IXOBoard xOBoard)
        {
            if (range == -1)
            {
                range = (xOBoard.Size) * (xOBoard.Size) - 1;
                cells = new Dictionary<int, int>();
                for (int i = 0; i <= range; i++)
                    cells.Add(i, i);
            }
            Random rnd = new Random();
            bool success = false;
            while (!success && range >= 0)
            {
                int temp = rnd.Next(0, range + 1);
                int cell = cells[temp];
                _lastRow = cell / (xOBoard.Size);
                _lastCol = cell % (xOBoard.Size);
                success = xOBoard.Put(Identity, _lastRow, _lastCol);
                cells[temp] = cells[range];
                cells.Remove(range);
                range--;
            }
            if (!success)
                range = -1;
            return success;
        }
    }
}