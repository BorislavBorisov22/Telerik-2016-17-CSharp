using System;
using System.Linq;
using System.Collections.Generic;

class SequenceInMatrix
{
    static int maxSequence = 1;
    private static void ReadFieldNumbers(int[,] field, int rowsToRead)
    {
        for (int row = 0; row < rowsToRead; row++)
        {
            var currRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int col = 0; col < currRow.Length; col++)
            {
                field[row, col] = currRow[col];
            }
        }
    }
    static void Main()
    {
        string[] sizesField = Console.ReadLine().Split(new char[] { ' ' }
        , StringSplitOptions.RemoveEmptyEntries);
        int heightField = int.Parse(sizesField[0]);
        int widthField = int.Parse(sizesField[1]);

        int[,] field = new int[heightField, widthField];

        ReadFieldNumbers(field, heightField);

        CheckFieldRows(field);
        CheckFieldCols(field);
        CheckAllStraightDiagonals(field);
        CheckAllReversedDiagonals(field);

        Console.WriteLine(maxSequence);
    }
    private static void CheckSequence(List<int> sequence)
    {
        int currSequenceCount = 1;
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            if (sequence[i] == sequence[i + 1])
            {
                currSequenceCount++;
                if (currSequenceCount > maxSequence)
                {
                    maxSequence = currSequenceCount;
                }
            }
            else
            {
                if (currSequenceCount > maxSequence)
                {
                    maxSequence = currSequenceCount;
                }
                currSequenceCount = 1;
            }
        }
    }

    private static void CheckAllStraightDiagonals(int[,] field)
    {
        //up to main diagonal
        for (int row = field.GetLength(0) - 1; row >= 0; row--)
        {
            int tempRow = row;
            int tempCol = 0;
            var currDiagonal = new List<int>();

            while (tempRow < field.GetLength(0) && tempCol < field.GetLength(1))
            {
                currDiagonal.Add(field[tempRow, tempCol]);

                tempRow++;
                tempCol++;
            }
            CheckSequence(currDiagonal);
        }

        //after main diagonal
        for (int col = 1; col < field.GetLength(1); col++)
        {
            int tempRow = 0;
            int tempCol = col;
            var currDiagonal = new List<int>();

            while (tempRow < field.GetLength(0) && tempCol < field.GetLength(1))
            {
                currDiagonal.Add(field[tempRow, tempCol]);

                tempRow++;
                tempCol++;
            }
            CheckSequence(currDiagonal);

        }
    }

    private static void CheckFieldCols(int[,] field)
    {

        for (int col = 0; col < field.GetLength(1); col++)
        {
            int currentSequenceCount = 1;
            for (int row = 0; row < field.GetLength(0) - 1; row++)
            {
                if (field[row, col] == field[row + 1, col])
                {
                    currentSequenceCount++;
                    if (currentSequenceCount > maxSequence)
                    {
                        maxSequence = currentSequenceCount;
                    }

                }
                else
                {
                    if (currentSequenceCount > maxSequence)
                    {
                        maxSequence = currentSequenceCount;
                    }
                    currentSequenceCount = 1;
                }
            }
        }
    }

    private static void CheckFieldRows(int[,] field)
    {

        for (int row = 0; row < field.GetLength(0); row++)
        {
            int currSequenceCount = 1;
            for (int col = 0; col < field.GetLength(1) - 1; col++)
            {
                if (field[row, col] == field[row, col + 1])
                {
                    currSequenceCount++;
                    if (currSequenceCount > maxSequence)
                    {
                        maxSequence = currSequenceCount;
                    }
                    else
                    {
                        if (currSequenceCount > maxSequence)
                        {
                            maxSequence = currSequenceCount;
                        }
                        currSequenceCount = 1;
                    }
                }
            }
        }
    }
    private static void CheckAllReversedDiagonals(int[,] field)
    {
        // up to main diagonal
        for (int row = field.GetLength(0) - 1; row >= 0; row--)
        {
            int tempRow = row;
            int tempCol = field.GetLength(1) - 1;
            var currDiagonal = new List<int>();

            while (tempRow < field.GetLength(0) && tempCol >= 0)
            {
                currDiagonal.Add(field[tempRow, tempCol]);
                tempRow++;
                tempCol--;
            }
            CheckSequence(currDiagonal);
        }
        //above main diagonal
        for (int col = field.GetLength(1) - 2; col >= 0; col--)
        {
            int tempRow = 0;
            int tempCol = col;
            var currDiagonal = new List<int>();
            while (tempCol >= 0 && tempRow < field.GetLength(0))
            {
                currDiagonal.Add(field[tempRow, tempCol]);
                tempRow++;
                tempCol--;
            }
            CheckSequence(currDiagonal);
        }
    }
}

