using System;
using System.Collections.Generic;
using System.Linq;

namespace Grid
{
    public class PlayGrid
    {
        public List<List<int>> Grid { get; private set; }
        private Random random = new Random();

        public PlayGrid(int rows, int columns)
        {
            Grid = new List<List<int>>(rows);

            // Initialisation de la première ligne
            List<int> firstRow = new List<int>(Enumerable.Repeat(9, columns));
            Grid.Add(firstRow);

            // Initialisation des lignes intermédiaires
            for (int i = 0; i < rows - 2; i++)
            {
                List<int> row = new List<int>(new int[columns]);
                row[0] = 9; // Mur à gauche
                row[columns - 1] = 9; // Mur à droite
                Grid.Add(row);
            }

            // Initialisation de la dernière ligne
            List<int> lastRow = new List<int>(Enumerable.Repeat(9, columns));
            Grid.Add(lastRow);
        }

        // Récupérer la grille actuelle
        public List<List<int>> GetGrid()
        {
            return Grid;
        }

        public void UpdateCell(int x, int y, int value)
        {
            Grid[y][x] = value; // Met à jour la valeur de la cellule à la position (x, y)
        }

        public void ClearGrid()
        {
            for (int i = 0; i < Grid.Count; i++)
            {
                for (int j = 0; j < Grid[i].Count; j++)
                {
                    Grid[i][j] = 0; // Réinitialise toutes les cellules à 0
                }
            }
        }

        // Vérifie si une pomme existe
        public bool HasApple()
        {
            return Grid.Sum(row => row.Count(cell => cell == 8)) >= 3;
        }

        // Génère une pomme à une position aléatoire
        public void GenerateApple()
        {
            if (!HasApple())
            {
                int x, y;
                do
                {
                    x = random.Next(1, Grid[0].Count - 1);
                    y = random.Next(1, Grid.Count - 1);
                }
                while (Grid[y][x] != 0); // Continue tant que la case est occupée

                Console.WriteLine($"pomme en X: {x}, Y: {y}");
                this.UpdateCell(x, y, 8); // Place la pomme (représentée par le chiffre 8)
            }
        }
        public bool IsDefeated()
        {
            return !Grid.Any(row => row.Contains(1)); // Par exemple, le joueur est "défait" s'il n'y a plus de cellule avec la valeur 1
        }

        public object CheckDefeat()
        {
            if (IsDefeated())
            {
                return 1;
            }
            else
            {
                return GetGrid();
            }
        }


        public void PrintGrid()
        {
            foreach (var row in Grid)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
