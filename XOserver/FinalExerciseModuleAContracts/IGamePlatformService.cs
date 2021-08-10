using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IGamePlatformService
    {
        public IUserService UserService { get; set; }
        public int AddGame(IGame game);
        public IGame GetGame(int token);
        public void CloseGame(int token, string result);
    }
}