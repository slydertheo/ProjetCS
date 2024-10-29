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
            Position head = BodyParts[0];
            Position newHead = head;

            switch (Direction)
            {
                case 'U': newHead = new Position(head.X, head.Y - 1); break;
                case 'D': newHead = new Position(head.X, head.Y + 1); break;
                case 'L': newHead = new Position(head.X - 1, head.Y); break;
                case 'R': newHead = new Position(head.X + 1, head.Y); break;
            }

            if (BodyParts.Any(part => part.X == newHead.X && part.Y == newHead.Y))
            {
                Console.WriteLine("Collision détectée avec le corps du serpent !");
                _grid.ClearGrid();
                return;
            }
            else if (_grid.GetGrid()[newHead.X][newHead.Y] == 9)
            {
                Console.WriteLine("Collision détectée avec le mur !");
                _grid.ClearGrid();
                return;
            }
            else{
                Position tail = BodyParts[BodyParts.Count - 1];
                _grid.UpdateCell(tail.X, tail.Y, 0);

                for (int i = BodyParts.Count - 1; i > 0; i--)
                {
                    BodyParts[i] = BodyParts[i - 1];
                }

                BodyParts[0] = newHead;
                _grid.UpdateCell(newHead.X, newHead.Y, 1);
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
