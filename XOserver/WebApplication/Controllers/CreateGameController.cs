using CreateGameDTO;
using DALContract;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserServiceDTO;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CreateGameController : Controller
    {
        IXOBoard _board;
        IPlayer _bot;
        IGamePlatformService _gamePlatformService;
        IGame _newGame;
        public CreateGameController(IXOBoard board, IPlayer bot, IGamePlatformService gamePlatformService, IGame game, IUserService userService, IDAL Idal)
        {
            _newGame = game;
            _board = board;
            _bot = bot;
            bot.Identity = XorO.O;
            _gamePlatformService = gamePlatformService;
            _gamePlatformService.UserService = userService;
            userService.Idal = Idal;
        }
        [HttpPost]
        public CreateGameResponseDTO Post([FromBody] RegisterDTO request)
        {
            _newGame.Initialization(request.ID, request.Name, _board, _bot);
            int token = _gamePlatformService.AddGame(_newGame);
            string message = "The Game Start successfully. Good luck!";
            if (token == 0)
                message = "User does not exist or login details incorrect";
            return new CreateGameResponseDTO(token, message);
        }
    }
}