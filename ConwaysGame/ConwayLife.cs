using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace ConwaysGame
{
    public class ConwayLife
    {
        /* Please note that the htmlize function for C# currently isn't working
            properly. I tested it on rextester.com and the code worked as expected,
            but for some reason on codewars it isn't. When I find a solution to
            the issue I will update the function. */
        public static int[,] GetGeneration(int[,] cells, int generation)
        {
            // Console.WriteLine($"{cells.GetLength(0)}x{cells.GetLength(1)}");
            // Console.WriteLine(generation);

            for (int i = 0; i <= generation; i++)
            {
                // Console.WriteLine($"Generation: {i}");
                Console.Clear();
                Display(cells);
                Thread.Sleep(500);
                cells = DoGeneration(cells);
            }

            // Console.WriteLine("Before Crop");
            // Display(cells);
            // cells = Crop(cells);
            // Console.WriteLine("Final");
            Console.Clear();
            Display(cells);
            return cells;

        }

        public static int[,] DoGeneration(int[,] cells)
        {
            int[,] result = new int[cells.GetLength(0), cells.GetLength(1)];

            //int rightCol = 0;
            //int leftCol = 0;
            //int topRow = 0;
            //int bottomRow = 0;



            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    //Console.WriteLine($"i:{i} j:{j} cells:{cells[i,j]}");
                    result[i, j] = CheckCell(cells, i, j);

                    //if (result[0, j] == 1 && (j > 0 ? (result[0, j - 1] == 1) : true)) { topRow++; }
                    //if (result[result.GetLength(0) - 1, j] == 1 && (j > 0 ? (result[result.GetLength(0) - 1, j - 1] == 1) : true)) { bottomRow++; }
                }

                //if (result[i, 0] == 1 && (i > 0 ? (result[i - 1, 0] == 1) : true)) { leftCol++; }

                //if (result[i, result.GetLength(1) - 1] == 1 && (i > 0 ? (result[i - 1, cells.GetLength(1) - 1] == 1) : true)) { rightCol++; }

                //  Console.WriteLine();
            }

            // int nextI = cells.GetLength(0);
            // int nextJ = cells.GetLength(1);



            // Anticipate growth and resize array
            //if (topRow >= 2)
            //{
            //    // add row to top
            //    // Console.WriteLine("Add Top Row");
            //    result = AddTopRow(result);
            //    //nextI++;
            //}
            //if (bottomRow >= 2)
            //{
            //    // add row to bottom
            //    // Console.WriteLine("Add Bottom Row");
            //    result = AddBottomRow(result);
            //    // nextI++;
            //}
            //if (leftCol >= 2)
            //{
            //    // add col to left
            //    // Console.WriteLine("Add Left Col");
            //    result = AddLeftCol(result);
            //    // nextJ++;
            //}
            //if (rightCol >= 2)
            //{
            //    // add col to right
            //    // Console.WriteLine("Add Right Col");
            //    result = AddRightCol(result);
            //    // nextJ++;
            //}

            //Display(result);

            return result;
        }

        public static int[,] Crop(int[,] cells)
        {
            int rightColCount = 0;
            int leftColCount = 0;
            int topRowCount = 0;
            int bottomRowCount = 0;

            do
            {
                rightColCount = 0;
                leftColCount = 0;
                topRowCount = 0;
                bottomRowCount = 0;
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        if (cells[0, j] == 1) { topRowCount++; }
                        if (cells[cells.GetLength(0) - 1, j] == 1) { bottomRowCount++; }
                    }
                    if (cells[i, cells.GetLength(1) - 1] == 1) { rightColCount++; }
                    if (cells[i, 0] == 1) { leftColCount++; }
                }

                if (topRowCount == 0)
                {
                    // remove top row
                    // Console.WriteLine("Remove Top Row");
                    cells = RemoveTopRow(cells);
                    // nextI--;
                }
                if (bottomRowCount == 0)
                {
                    // remove bottom row
                    // Console.WriteLine("Remove Bottom Row");
                    cells = RemoveBottomRow(cells);
                    // nextI--;
                }
                if (leftColCount == 0)
                {
                    // remove left column
                    // Console.WriteLine("Remove Left Col");
                    cells = RemoveLeftCol(cells);
                    // nextJ--;
                }
                if (rightColCount == 0)
                {
                    // remove right column
                    // Console.WriteLine("Remove Right Col");
                    cells = RemoveRightCol(cells);
                    // nextJ--;
                }
                // Console.WriteLine($"top{topRowCount}, bottom{bottomRowCount}, left{leftColCount}, right{rightColCount}");
            } while (rightColCount == 0 || leftColCount == 0 || topRowCount == 0 || bottomRowCount == 0);

            return cells;
        }

        public static int[,] RemoveTopRow(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0) - 1, old.GetLength(1)];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < old.GetLength(1); j++)
                {
                    newCells[i, j] = old[i + 1, j];
                }
            }
            return newCells;

        }

        public static int[,] RemoveBottomRow(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0) - 1, old.GetLength(1)];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < old.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j];
                }
            }
            return newCells;
        }

        public static int[,] RemoveLeftCol(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0), old.GetLength(1) - 1];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < newCells.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j + 1];
                }
            }
            return newCells;
        }

        public static int[,] RemoveRightCol(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0), old.GetLength(1) - 1];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < old.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j];
                }
            }
            return newCells;
        }

        public static int[,] AddTopRow(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0) + 1, old.GetLength(1)];
            for (int i = 1; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < newCells.GetLength(1); j++)
                {
                    newCells[i, j] = old[i - 1, j];
                }
            }
            return newCells;
        }

        public static int[,] AddBottomRow(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0) + 1, old.GetLength(1)];
            for (int i = 0; i < old.GetLength(0); i++)
            {
                for (int j = 0; j < newCells.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j];
                }
            }
            return newCells;
        }

        public static int[,] AddLeftCol(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0), old.GetLength(1) + 1];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 1; j < newCells.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j - 1];
                }
            }
            return newCells;
        }

        public static int[,] AddRightCol(int[,] old)
        {
            int[,] newCells = new int[old.GetLength(0), old.GetLength(1) + 1];
            for (int i = 0; i < newCells.GetLength(0); i++)
            {
                for (int j = 0; j < old.GetLength(1); j++)
                {
                    newCells[i, j] = old[i, j];
                }
            }
            return newCells;
        }




        public static void Display(int[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j] == 1)
                        Console.Write("░░");
                    else
                        Console.Write("▓▓");
                }
                Console.WriteLine();
            }
        }

        public static int CheckCell(int[,] cells, int i, int j)
        {
            int nw = (i != 0 && j != 0) ? cells[i - 1, j - 1] : 0;
            int n = (i != 0) ? cells[i - 1, j] : 0;
            int ne = (i != 0 && j != cells.GetLength(1) - 1) ? cells[i - 1, j + 1] : 0;
            int w = (j != 0) ? cells[i, j - 1] : 0;
            int e = (j != cells.GetLength(1) - 1) ? cells[i, j + 1] : 0;
            int sw = (i != cells.GetLength(0) - 1 && j != 0) ? cells[i + 1, j - 1] : 0;
            int s = (i != cells.GetLength(0) - 1) ? cells[i + 1, j] : 0;
            int se = (i != cells.GetLength(0) - 1 && j != cells.GetLength(1) - 1) ? cells[i + 1, j + 1] : 0;

            //       Console.WriteLine($"nw:{nw}");
            //       Console.WriteLine($"n:{n}");
            //       Console.WriteLine($"ne:{ne}");
            //       Console.WriteLine($"w:{w}");
            //       Console.WriteLine($"e:{e}");
            //       Console.WriteLine($"sw:{sw}");
            //       Console.WriteLine($"s:{s}");
            //       Console.WriteLine($"se:{se}");

            List<int> neighbors = new List<int> { nw, n, ne, w, e, sw, s, se };
            int sum = neighbors.Sum();
            if (cells[i, j] == 0)
            {
                if (sum == 3) { return 1; }
            }
            else
            {
                if (sum == 2 || sum == 3) { return 1; }
            }

            return 0;
        }

    }

}




