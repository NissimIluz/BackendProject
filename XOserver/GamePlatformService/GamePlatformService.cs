using Contracts;
using System;
using System.Collections.Generic;
using GameImpl;
using UserServiceImpl;
using InfraAttributes;

namespace GamePlatformServiceImp
{
    [Register(typeof(IGamePlatformService))]
    [Policy(Policy.Singleton)]
    public class GamePlatformService : IGamePlatformService
    {
        private Dictionary<int, IGame> _games = new Dictionary<int, IGame>();

        IUserService _userService = null;
        public IUserService UserService
        {
            get { return _userService; }
            set
            {
                if (_userService == null)
                    _userService = value;
            }
        }
        public int AddGame(IGame game)
        {
            int token;
            if (_userService.Login(game.UserID, game.UserName))
            {
                do
                {
                    token = CreateToken();
                } while (_games.ContainsKey(token) && _userService.TokenExist(token));
                _games.Add(token, game);
            }
            else
            {
                token = 0;
            }
            return token;
        }
        public IGame GetGame(int token)
        {
            IGame retval = null;
            if (_games.ContainsKey(token))
                retval = _games[token];
            return retval;
        }
        public void CloseGame(int token, string result)
        {
            _userService.RegisterGame(token, _games[token].UserID, _games[token].UserName, _games[token].Bot.GetType().FullName, result);
            _games.Remove(token);
        }
        private int CreateToken()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 1000000);
        }

    }
}