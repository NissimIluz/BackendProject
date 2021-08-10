using System;
using System.Collections.Generic;
using System.Text;


namespace Contracts
{
    public interface IGame
    {
        public void Initialization(string UserID, string userName, IXOBoard board, IPlayer boot);
        public IXOBoard Board { get; }
        public IPlayer Bot { get; }
        public string UserID { get; }
        public string UserName { get; }
        public XorO[][] RetBoard { get; }

    }
}