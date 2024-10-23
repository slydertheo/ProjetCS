using System;
using System.Collections.Generic;
using System.Linq; 

namespace Grid
{
    public class PlayGrid
    {
        public List<List<int>> Grid { get; set; }

        public PlayGrid(int rows, int columns)
        {
            Grid = new List<List<int>>(rows);

            List<int> FirstRow = new List<int>(Enumerable.Repeat(9, columns));
            Grid.Add(FirstRow);

            for (int i = 0; i < rows - 2; i++)
            {
                List<int> row = new List<int>(new int[columns]);
                row[0] = 9;
                row[columns - 1] = 9;
                Grid.Add(row);
            }

            List<int> LastRow = new List<int>(Enumerable.Repeat(9, columns));
            Grid.Add(LastRow);
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
