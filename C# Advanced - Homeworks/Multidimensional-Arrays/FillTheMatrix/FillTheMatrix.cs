using System;



class FillTheMatrix
{
    static void Main()
    {
        int sizeMatrix = int.Parse(Console.ReadLine());
        char typeFilling = (char)Console.Read();

        int[,] matrix = new int[sizeMatrix, sizeMatrix];

        switch (typeFilling)
        {
            case 'a': FillTypeA(matrix); break;
            case 'b': FillTypeB(matrix); break;
            case 'c': FillTypeC(matrix); break;
            case 'd': FillTypeD(matrix); break;
        }


        PrintMatrix(matrix);

    }

    private static void FillTypeD(int[,] matrix)
    {
        int row = 0;
        int col = 0;
        string direction = "down";
        for (int i = 0; i < matrix.GetLength(0) * matrix.GetLength(1); i++)
        {
            if (direction == "down" && (row == matrix.GetLength(0) || matrix[row,col] != 0))
            {
                row--;
                col++;
                direction = "right";
            }
            else if (direction == "right" && (col == matrix.GetLength(1) || matrix[row,col] != 0))
            {
                col--;
                row--;
                direction = "up";
            }
            else if (direction == "up" && (row < 0 || matrix[row,col] != 0))
            {
                row++;
                col--;
                direction = "left";
            }
            else if (direction == "left" && (col < 0 || matrix[row,col] != 0))
            {
                col++;
                row++;
                direction = "down";
            }

            matrix[row, col] = i + 1;

            if (direction == "right")
            {
                col++;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "up")
            {
                row--;
            }
        }
    }

    private static void FillTypeC(int[,] matrix)
    {

        // fill matrix up to main diagonal
        int numberToFill = 1;
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            int tempRow = row;
            int tempCol = 0;
            while (tempRow < matrix.GetLength(0))
            {
                matrix[tempRow, tempCol] = numberToFill;
                tempRow++;
                tempCol++;
                numberToFill++;
            }

        }

        // fill matrix after main diagonal
        for (int col = 1; col < matrix.GetLength(1); col++)
        {
            int tempRow = 0;
            int tempCol = col;
            while (tempCol < matrix.GetLength(1))
            {
                matrix[tempRow, tempCol] = numberToFill;
                tempRow++;
                tempCol++;
                numberToFill++;
            }
        }

    }

    private static void FillTypeB(int[,] matrix)
    {
        int numberToFill = 1;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = numberToFill;
                    numberToFill++;
                }
            }
            else
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix[row, col] = numberToFill;
                    numberToFill++;
                }
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    Console.Write(matrix[row, col]);
                }
                else
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
            }
            Console.WriteLine();
        }
    }

    private static void FillTypeA(int[,] matrix)
    {
        int numberToFill = 1;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = numberToFill;
                numberToFill++;
            }
        }
    }
}

