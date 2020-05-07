using System;
using System.Collections.Generic;

namespace WallsAndGates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void WallsAndGates(int[][] rooms)
        {
            var(row, col) = (rooms.Length, rooms[0].Length);
            Queue < (int row, int col) > queue = new Queue < (int row, int col) > ();

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (rooms[r][c] == 0)
                        queue.Enqueue((r, c));
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var directions = new []
                {
                    (-1, 0), (1, 0), (0, 1), (0, -1)
                };

                foreach (var d in directions)
                {
                    var currentVal = rooms[current.row][current.col];
                    var(neighborRow, neighborCol) = (current.row + d.Item1, current.col + d.Item2);
                    if (neighborRow >= 0 && neighborCol < row && neighborCol >= 0 && neighborCol < col)
                    {
                        if (rooms[neighborRow][neighborCol] > currentVal + 1)
                        {
                            rooms[neighborRow][neighborCol] = currentVal + 1;
                            queue.Enqueue((neighborRow, neighborCol));
                        }
                    }
                }
            }
        }
    }
}