using Microsoft.AspNetCore.Mvc;
using back_end_Cs.Models;
using System.Collections.Generic;

namespace back_end_Cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakeController : ControllerBase
    {
        private static List<Snake> Snakes = new List<Snake>
        {
            new Snake { Id = 1, Size = "12", Direction = "up" },
            new Snake { Id = 2, Size = "30", Direction = "left" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Snake>> GetSnakes()
        {
            return Ok(Snakes);
        }
    }
}
