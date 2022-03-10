using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GameOfLife
    {
        public static void Main()
        {
            int[,] grid = new int[25, 25];

            Console.WriteLine("Which generation's population positions are you interested in?");
            int noOfGenerations = int.Parse(Console.ReadLine());

            Console.WriteLine("Provide the population positions of Generation ZERO:");

            int[] positions = new int[20];
            for (int i = 0; i < 20; i++)
            {
                positions[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < positions.Length - 1; i++)
            {
                grid[positions[i], positions[i + 1]] = 1;
                i += 1;
            }

            futureGenerations(grid, noOfGenerations);
        }

        static void futureGenerations(int[,] grid, int noOfGenerations)
        {

            int row = 25;
            int col = row;

            int[,] future = new int[row, col];

            for (int generation = 1; generation <= noOfGenerations; generation++)
            {

                for (int l = 1; l < row - 1; l++)
                {
                    for (int m = 1; m < col - 1; m++)
                    {

                        int aliveNeighbours = 0;
                        for (int i = -1; i <= 1; i++)
                            for (int j = -1; j <= 1; j++)
                                aliveNeighbours +=
                                        grid[l + i, m + j];

                        aliveNeighbours -= grid[l, m];

                        if ((grid[l, m] == 1) &&
                                    (aliveNeighbours < 2))
                            future[l, m] = 0;

                        else if ((grid[l, m] == 1) &&
                                    (aliveNeighbours > 3))
                            future[l, m] = 0;

                        else if ((grid[l, m] == 0) &&
                                    (aliveNeighbours == 3))
                            future[l, m] = 1;

                        else
                            future[l, m] = grid[l, m];

                    }
                }

                Console.WriteLine("Generation " + generation);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (future[i, j] == 1)

                            Console.WriteLine("[(" + i + "," + j + ")]");
                    }
                }

                grid = future;
            }
        }

    }
}
