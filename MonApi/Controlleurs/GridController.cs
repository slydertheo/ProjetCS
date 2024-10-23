using Microsoft.AspNetCore.Mvc;
using Grid; 
using System.Collections.Generic;

namespace MonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class gridController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGrid()
        {
            PlayGrid gameGrid = new PlayGrid(30, 30);
            var gridData = gameGrid.GetGrid();
            return Ok(gridData); 
        }
    }
}

