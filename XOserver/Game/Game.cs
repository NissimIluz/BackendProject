using Contracts;
using InfraAttributes;
using System;

namespace GameImpl
{
    [Register(typeof(IGame))]
    [Policy(Policy.Transient)]
    public class Game : IGame
    {
        string _userID = null;
        string _userName;
        IXOBoard _board;
        IPlayer _bot;
        XorO[][] _retBoard;
        public Game() { }
        public void Initialization(string UserID, string userName, IXOBoard board, IPlayer bot)
        {
            if (_userID == null)
            {
                _userID = UserID;
                _userName = userName;
                _board = board;
                _bot = bot;
                _retBoard = new XorO[_board.Size][];
                for (int i = 0; i < _board.Size; i++)
                {
                    _retBoard[i] = new XorO[_board.Size];
                    for (int j = 0; j < _board.Size; j++)
                        _retBoard[i][j] = XorO.Empty;
                }
            }
        }
        public IXOBoard Board { get { return _board; } }
        public IPlayer Bot { get { return _bot; } }
        public string UserID { get { return _userID; } }
        public string UserName { get { return _userName; } }
        public XorO[][] RetBoard { get { return _retBoard; } }
    }
}