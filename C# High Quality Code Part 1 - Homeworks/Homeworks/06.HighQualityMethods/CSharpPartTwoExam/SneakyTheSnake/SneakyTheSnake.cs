namespace Methods.CSharpPartTwoExam._03.SneakyTheSnake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SneakyTheSnake
    {
        private static int snakeLength = 3;
        private static int snakeRow = 0;
        private static int snakeCol = 0;
        private static char[,] matrix;

        public static void Main()
        {
            // read input
            string[] rowsAndColsInfo = Console.ReadLine().Split('x');

            int rows = int.Parse(rowsAndColsInfo[0]);
            int cols = int.Parse(rowsAndColsInfo[1]);

            matrix = ReadMatrix(rows, cols);

            char[] directions = 
                 Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            bool isFree = false;
            bool isLostInDepth = false;
            bool hitARock = false;
            bool lostLength = false;

            int movesCount = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                if (IsSnakeStarvingToDeath())
                {
                    lostLength = true;
                    break;
                }

                char currentDirection = directions[i];
                UpdateSnakePosition(currentDirection);

                movesCount++;
                UpdateSnakeLength(movesCount);

                UpdateSnakeCols();

                if (IsSnakeLostInDepth())
                {
                    isLostInDepth = true;
                    break;
                }

                if (IsSnakeOnFood())
                {
                    snakeLength++;
                    matrix[snakeRow, snakeCol] = '-';
                }
                else if (HasSnakeHitRockBottom())
                {
                    hitARock = true;
                    break;
                }
                else if (IsSnakeFree())
                {
                    isFree = true;
                    break;
                }
            }

            if (isFree)
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", snakeLength);
            }
            else if (hitARock)
            {
                Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", snakeRow, snakeCol);
            }
            else if (isLostInDepth)
            {
                Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", snakeLength);
            }
            else if (lostLength)
            {
                Console.WriteLine("Sneaky is going to starve at [{0},{1}]", snakeRow, snakeCol);
            }
            else
            {
                Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", snakeRow, snakeCol);
            }
        }

        private static bool IsSnakeStarvingToDeath()
        {
            return snakeLength <= 0;
        }

        private static bool IsSnakeFree()
        {
            return matrix[snakeRow, snakeCol] == 'e';
        }

        private static bool HasSnakeHitRockBottom()
        {
            return matrix[snakeRow, snakeCol] == '%';
        }

        private static bool IsSnakeOnFood()
        {
            return matrix[snakeRow, snakeCol] == '@';
        }

        private static bool IsSnakeLostInDepth()
        {
            return snakeRow >= matrix.GetLength(0);
        }

        private static void UpdateSnakeCols()
        {
            if (snakeCol < 0)
            {
                snakeCol = matrix.GetLength(1) - 1;
            }
            else if (snakeCol >= matrix.GetLength(1))
            {
                snakeCol = 0;
            }
        }

        private static void UpdateSnakeLength(int movesCount)
        {
            if (movesCount % 5 == 0)
            {
                snakeLength--;
            }
        }

        private static void UpdateSnakePosition(char direction)
        {
            if (direction == 'w')
            {
                snakeRow--;
            }
            else if (direction == 's')
            {
                snakeRow++;
            }
            else if (direction == 'd')
            {
                snakeCol++;
            }
            else if (direction == 'a')
            {
                direction--;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    if (currentLine[col] == 'e')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    matrix[row, col] = currentLine[col];
                }
            }

            return matrix;
        }
    }
}
