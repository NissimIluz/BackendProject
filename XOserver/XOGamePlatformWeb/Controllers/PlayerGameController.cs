using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOboardRandomPlayer;
using XOContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class PlayerGameController : ControllerBase
    {
        IXOBoard _board;
        IPlayer _boot;
        public PlayerGameController(IXOBoard board, IPlayer boot)
        {
            _board = board;
            _boot = boot;
            boot.Identity = XorO.X;
        }
        // POST api/<RandomPlayerGameController>
        [HttpPost]
        public XOCellExpandedResponseDTO Post([FromBody] XOCellDTO cell)
        {   
            var retval = new XOCellExpandedResponseDTO();
            retval.Succeed = _board.Put(XorO.X,cell.Row,cell.Col);
            if (retval.Succeed)
            {
                _boot.makeMove(_board);
                retval.ComputerMove[0] = _boot.LastRow;
                retval.ComputerMove[1] = _boot.LastCol;
                retval.Status = _board.getStatus();
            }
            return retval;
        }
    }
}
