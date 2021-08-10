using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamePlayDTO;
using UserServiceDTO;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        IGamePlatformService _gamePlatformService;


        public GameController(IGamePlatformService gamePlatformService)
        {
            _gamePlatformService = gamePlatformService;
        }
        [HttpPost]
        public PlayResponseDTO Post([FromBody] PlayDTO move)
        {
            PlayResponseDTO retval = new PlayResponseDTO();
            IGame gamePointer = _gamePlatformService.GetGame(move.Token);
            if (gamePointer == null)
            {
                retval.Succeed = false;
                retval.Message = "Token did not found!";
            }
            else
            {
                retval.Succeed = gamePointer.Board.Put(XorO.X, move.Row, move.Col);
                retval.Status = gamePointer.Board.getStatus();
                if (retval.Succeed && retval.Status == Status.None)
                {
                    gamePointer.RetBoard[move.Row][move.Col] = XorO.X;
                    IPlayer botPointer = _gamePlatformService.GetGame(move.Token).Bot;
                    gamePointer.Bot.makeMove(gamePointer.Board);
                    gamePointer.RetBoard[botPointer.LastRow][botPointer.LastCol] = XorO.O;
                    retval.Status = gamePointer.Board.getStatus();
                    retval.Message = "Your turn";
                }
                else
                    retval.Message = "Invalid move";
                if (retval.Status != Status.None)
                {
                    string result = retval.Status.ToString();
                    if (retval.Status == Status.None)
                        retval.Message = "The game ended. no winner.";
                    else
                        retval.Message = Status.X == retval.Status ? "You Won" : "I won";
                    _gamePlatformService.CloseGame(move.Token, result);
                }
                retval.RetBoard = gamePointer.RetBoard;
            }
            return retval;
        }
    }
}