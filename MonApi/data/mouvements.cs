// using System;

// namespace SnakeGame
// {
//     public class SnakeMovement
//     {
//         public int SnakeX { get; set; }
//         public int SnakeY { get; set; }
//         public char Direction { get; set; } = 'R'; 

//         private PlayGrid _grid;

//         public SnakeMovement(PlayGrid grid)
//         {
//             _grid = grid;
//             //milieu de la grille
//             SnakeX = grid.GetGrid()[0].Count / 2;
//             SnakeY = grid.GetGrid().Count / 2;
//             _grid.UpdateCell(SnakeX, SnakeY, 1); // 1 pour le serpent
//         }

//         public void ChangeDirection(char newDirection)
//         {
//             Direction = newDirection;
//         }

//         public void MoveSnake()
//         {

//             _grid.UpdateCell(SnakeX, SnakeY, 0); //update l'ancienne position du poto

//             switch (Direction)
//             {
//                 case 'U': SnakeY--; break; //haut 
//                 case 'D': SnakeY++; break; //bas
//                 case 'L': SnakeX--; break; //gauche
//                 case 'R': SnakeX++; break; //droite
//             }

//             SnakeX = Math.Max(0, Math.Min(SnakeX, _grid.GetGrid()[0].Count - 1)); // collision avec le mure si il tapen sont gros front sur le mure 
//             SnakeY = Math.Max(0, Math.Min(SnakeY, _grid.GetGrid().Count - 1)); // pareille 


//             _grid.UpdateCell(SnakeX, SnakeY, 1);
//         }

//         public void PrintGrid()
//         {
//             _grid.ClearGrid(); // Nettoie la grille d'abord
//             _grid.UpdateCell(SnakeX, SnakeY, 1); // Remet le serpent à jour

//             foreach (var row in _grid.GetGrid())
//             {
//                 Console.WriteLine(string.Join(" ", row)); //strin join pour convert les lignes en chaines de caractères 
//             }
//         }
//     }
// }
