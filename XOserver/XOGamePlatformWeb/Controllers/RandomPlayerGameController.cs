using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOboardRandomPlayer;
using XOContracts;

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomPlayerGameController : PlayerGameController
    {
        public RandomPlayerGameController(IXOBoard board, IRandomPlayer boot)
            :base(board, boot) {}
    }
}
