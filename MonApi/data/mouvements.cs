using System;
using System.Collections.Generic;
using Grid;

namespace SnakeMouvement
{
    public class Snake
    {
        public List<Position> BodyParts { get; private set; }
        public char Direction { get; set; } = 'R'; // Direction par défaut

        private PlayGrid _grid; // Référence à la grille

        public Snake(PlayGrid grid, int initialX, int initialY, int initialLength)
        {
            _grid = grid; // Assignation de la grille
            BodyParts = new List<Position>();

            // Initialisation du serpent avec une longueur donnée
            for (int i = 0; i < initialLength; i++)
            {
                BodyParts.Add(new Position(initialX - i, initialY)); // Corps derrière la tête
                _grid.UpdateCell(initialX - i, initialY, 1); // Met à jour la grille avec le corps du serpent
            }
        }

        public void ChangeDirection(char newDirection)
        {
            Direction = newDirection;
        }

        public void MoveSnake()
        {
            // Met à jour l'ancienne position de la queue
            Position tail = BodyParts[BodyParts.Count - 1];
            _grid.UpdateCell(tail.X, tail.Y, 0); // Efface l'ancienne position de la queue

            // Met à jour les positions de toutes les parties du corps
            for (int i = BodyParts.Count - 1; i > 0; i--)
            {
                BodyParts[i] = BodyParts[i - 1]; // Décale chaque partie du corps vers la position de la précédente
            }

            // Mise à jour de la position de la tête
            Position head = BodyParts[0];
            switch (Direction)
            {
                case 'U': BodyParts[0] = new Position(head.X, head.Y - 1); break; // Haut 
                case 'D': BodyParts[0] = new Position(head.X, head.Y + 1); break; // Bas
                case 'L': BodyParts[0] = new Position(head.X - 1, head.Y); break; // Gauche
                case 'R': BodyParts[0] = new Position(head.X + 1, head.Y); break; // Droite
            }

            // Met à jour la grille avec la nouvelle position de la tête
            _grid.UpdateCell(BodyParts[0].X, BodyParts[0].Y, 1);
        }

        public void PrintGrid()
        {
            _grid.ClearGrid(); // Nettoie la grille d'abord

            // Met à jour la grille avec toutes les positions du serpent
            foreach (var part in BodyParts)
            {
                _grid.UpdateCell(part.X, part.Y, 1); // Met à jour chaque partie du corps
            }

            // Affiche la grille
            foreach (var row in _grid.GetGrid())
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
