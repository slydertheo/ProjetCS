using Microsoft.AspNetCore.Mvc;
using Grid; 
using System.Collections.Generic;

namespace MonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGrid()
        {
            PlayGrid gameGrid = new PlayGrid(10, 10);
            var gridData = gameGrid.GetGrid();
            return Ok(gridData); 
        }
    }
}

