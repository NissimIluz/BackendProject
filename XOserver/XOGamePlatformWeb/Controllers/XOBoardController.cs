using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOBoardMatImpl;
using XOContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XOBoardController : ControllerBase
    {
        IXOBoard _board;
        public XOBoardController(IXOBoard board)
        {
            _board = board; 
        }
        // GET: api/<XOBoardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // POST api/<XOBoardController>
        [HttpPost]
        public XOCellResponseDTO Post([FromBody] XOCellDTO cell)
        {
            var retval = new XOCellResponseDTO();
            XorO xoro = Enum.Parse<XorO>(cell.XorO);
           
            retval.Succeed = _board.Put(xoro, cell.Row, cell.Col);
            return retval; 

        }

    }
}
