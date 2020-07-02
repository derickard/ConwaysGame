using System;

namespace ConwaysGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[][,] gliders =
            {
                new int[,] {{1,0,0},{0,1,1},{1,1,0}},
                new int[,] {{0,1,0},{0,0,1},{1,1,1}}
            };

            int[,] roundTwo = new int[,] { { 1, 1, 1, 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0, 1 }, { 0, 1, 0, 0, 0, 1, 1, 1 } };

            // Console.WriteLine("Glider");
            ConwayLife.GetGeneration(gliders[0], 5);

            int [,] result = ConwayLife.GetGeneration(roundTwo, 16);
            Console.WriteLine($"{result.GetLength(0)}x{result.GetLength(1)}");
        }
    }
}
