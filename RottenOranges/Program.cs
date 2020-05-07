using System;
using System.Collections.Generic;

namespace RottenOranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int CountRound(int[][] grid)
        {
            var queue = new Queue < (int row, int col) > ();
            var freshOranges = 0;

            int Rows = grid.Length;
            int Columns = grid[0].Length;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                {
                    if (grid[i][j] == 2)
                        queue.Enqueue((i, j));
                    else if (grid[i][j] == 1)
                        freshOranges++;
                }

            queue.Enqueue((-1, -1));

            int round = -1;

            var directions = new List < (int, int) > ()
            {
                (-1, 0), (1, 0), (0, 1), (0, -1)
            };

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                if (currentCell.row == -1)
                {
                    // raise level
                    round++;
                    if (queue.Count > 0)
                    {
                        // add another level to avoid enless loop
                        queue.Enqueue((-1, -1));
                    }
                }
                else
                {

                    foreach (var direction in directions)
                    {
                        var(neighborRow, neighborColumn) = (currentCell.row + direction.Item1, currentCell.col + direction.Item2);
                        if (neighborRow >= 0 && neighborRow < Rows && neighborColumn >= 0 && neighborColumn < Columns)
                        {
                            if (grid[neighborRow][neighborColumn] == 1)
                            {
                                grid[neighborRow][neighborColumn] = 2;
                                queue.Enqueue((neighborRow, neighborColumn));
                                freshOranges--;
                            }
                        }
                    }
                }
            }

            if (freshOranges == 0)
                return round;
            return -1;
        }
    }
}