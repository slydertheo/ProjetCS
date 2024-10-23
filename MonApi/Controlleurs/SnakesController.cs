using Microsoft.AspNetCore.Mvc;
using MonApi.Models;
using System.Collections.Generic;

namespace MonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnakesController : ControllerBase
    {
        private static List<SnakeData> snakes = new List<SnakeData>
        {
            new SnakeData { Id = 1, Name = "Cobra", Habitat = "Forêts tropicales" },
            new SnakeData { Id = 2, Name = "Python", Habitat = "Savannes" },
        };

        [HttpGet]
        public IActionResult GetSnakes()
        {
            return Ok(snakes);
        }
    }
}
