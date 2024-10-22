using Microsoft.AspNetCore.Mvc;
using MonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetSnakes()
        {
            return Ok(snakes);
        }

        [HttpGet("print")]
        public async Task<IActionResult> PrintSnakes()
        {
            foreach (var snake in snakes)
            {
                Console.WriteLine($"Id: {snake.Id}, Name: {snake.Name}, Habitat: {snake.Habitat}");
            }
            return Ok("Snakes printed in console.");
        }
    }
}
