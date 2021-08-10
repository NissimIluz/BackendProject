using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XOBoardScanPlayer;
using XOContracts;

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanPlayerGameController : PlayerGameController
    {
        public ScanPlayerGameController(IXOBoard board, IScanPlayer boot)
           : base(board, boot) { }
    }
}

