using Microsoft.AspNetCore.Mvc;
using Grid;
using SnakeMouvement; // Ajoute ce using pour inclure la classe Snake
using System;
using System.Collections.Generic;

namespace MonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        // Instance statique pour maintenir l'état du jeu
        private static PlayGrid gameGrid = new PlayGrid(15, 15);
        private static Snake snake = new Snake(gameGrid, 6, 6, 3); // Utilisation de la classe Snake
        private static char currentDirection = 'R'; // Initialiser la direction vers le haut
        public GridController()
        {
            gameGrid.GenerateApple();
        }

        [HttpGet]
        public IActionResult GetGrid()
        {
            // Renvoyer la grille actuelle avec le serpent
            var gridData = gameGrid.GetGrid();
            return Ok(gridData);
        }

        [HttpPost]
        public IActionResult ReceiveKey([FromBody] KeyInput input)
        {

            // Modifier la direction selon la touche reçue (z, q, s, d)
            switch (input.Key.ToLower())
            {
                case "z":
                    if (currentDirection != 'D') { snake.ChangeDirection('U'); currentDirection = 'U'; }
                    break;
                case "s":
                    if (currentDirection != 'U') { snake.ChangeDirection('D'); currentDirection = 'D'; }
                    break;
                case "q":
                    if (currentDirection != 'R') { snake.ChangeDirection('L'); currentDirection = 'L'; }
                    break;
                case "d":
                    if (currentDirection != 'L') { snake.ChangeDirection('R'); currentDirection = 'R'; }
                    break;
                default:
                    break;
            }

            // Déplacer le serpent
            snake.MoveSnake();

            // Renvoyer la grille mise à jour
            return Ok(gameGrid.CheckDefeat());
        }

        [HttpPost("restart")]

        public IActionResult restart()
        {
            gameGrid = new PlayGrid(15,15);
            snake = new Snake(gameGrid, 6, 6, 3);
            currentDirection = 'R';
            gameGrid.GenerateApple();
            return Ok("Game restarted");
        }
    }

    // Classe pour représenter l'entrée de l'utilisateur
    public class KeyInput
    {
        public string Key { get; set; }
    }
}
