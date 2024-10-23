using System;
using System.Collections.Generic;

namespace main
{
    public class PlayGrid
    {
        public List<List<int>> Grid { get; set; }

        public PlayGrid(int rows, int columns)
        {
            Grid = new List<List<int>>(rows);
            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>(new int[columns]);
                Grid.Add(row);
            }
        }

        public List<List<int>> GetGrid()
        {
            return Grid;
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
