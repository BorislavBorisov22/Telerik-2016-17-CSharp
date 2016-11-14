using System;
using System.Collections.Generic;
using System.Linq;

class TesterProblems
{
    static int maxSequence = int.MinValue;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char ch = char.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int counter = 1;

        // Fill the matrix by char 'a'
        if (ch == 'a')
        {
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
        }
        // Fill the matrix by char 'b'
        else if (ch == 'b')
        {
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
        }
        // fill the matrix by char c
        else if (ch == 'c')
        {

            int row = n - 1;
            int col = 0;

            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = counter;
                row++;
                col++;
                counter++;

                if (row == n || col == n)
                {
                    row--;
                    if (col == n)
                    {
                        row--;
                        col--;
                    }
                    while (row - 1 >= 0 && col - 1 >= 0)
                    {
                        row--;
                        col--;
                    }
                }

            }
        }
        // fill the matrix by char 'd'
        else if (ch == 'd')
        {
            int row = 0;
            int col = 0;
            int maxRow = n - 1;
            int maxCol = n - 1;
            do
            {
                for (int i = row; i <= maxRow; i++)
                {
                    matrix[i, col] = counter;
                    counter++;
                }
                col++;

                for (int i = col; i <= maxCol; i++)
                {
                    matrix[maxRow, i] = counter;
                    counter++;
                }
                maxRow--;

                for (int i = maxRow; i >= row; i--)
                {
                    matrix[i, maxCol] = counter;
                    counter++;
                }
                maxCol--;

                for (int i = maxCol; i >= col; i--)
                {
                    matrix[row, i] = counter;
                    counter++;
                }
                row++;
            } while (counter <= n * n);
        }






        //print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col == (n - 1))
                {
                    Console.Write(matrix[row, col]);
                }
                else
                {
                    Console.Write(matrix[row, col] + " ");
                }
            }
            Console.WriteLine();
        }
          



    }



}

