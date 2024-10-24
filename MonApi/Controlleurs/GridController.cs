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
        private static PlayGrid gameGrid = new PlayGrid(30, 30);
        private static Snake snake = new Snake(gameGrid, 15, 15, 5); // Utilisation de la classe Snake

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
            // Traiter la touche reçue et déplacer le serpent
            Console.WriteLine($"Key received: {input.Key}");

            // Modifier la direction selon la touche reçue (z, q, s, d)
            switch (input.Key.ToLower())
            {
                case "z": snake.ChangeDirection('U'); break; // Haut
                case "s": snake.ChangeDirection('D'); break; // Bas
                case "q": snake.ChangeDirection('L'); break; // Gauche
                case "d": snake.ChangeDirection('R'); break; // Droite
                default: break;
            }

            // Déplacer le serpent
            snake.MoveSnake();

            // Renvoyer la grille mise à jour
            return Ok(gameGrid.GetGrid());
        }
    }

    // Classe pour représenter l'entrée de l'utilisateur
    public class KeyInput
    {
        public string Key { get; set; }
    }
}
