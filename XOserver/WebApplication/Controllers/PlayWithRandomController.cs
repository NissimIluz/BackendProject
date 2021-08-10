using DALContract;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayWithRandomController : CreateGameController
    {
        public PlayWithRandomController (IXOBoard board, IRandomPlayer bot, IGamePlatformService gamePlatformService, IGame game, IUserService userService, IDAL Idal)
            :base(board, bot, gamePlatformService, game, userService,Idal) {}
}
}
