using System;


namespace SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main()
        {
            int sizeField = int.Parse(Console.ReadLine());

            var field = new int[sizeField, sizeField];

            string direction = "right";

            int currRow = 0;
            int currCol = 0;
            for (int i=0;i<sizeField * sizeField; i++)
            {
                if (direction == "right" && (currCol == sizeField || field[currRow,currCol] != 0))
                {
                    currCol--;
                    currRow++;
                    direction = "down";
                }
                else if (direction == "down" && (currRow == sizeField || field[currRow, currCol] != 0))
                {
                    currRow--;
                    currCol--;
                    direction = "left";
                }
                else if (direction == "left" && (currCol < 0 || field[currRow, currCol] != 0))
                {
                    currRow--;
                    currCol++;
                    direction = "up";
                }
                else if (direction == "up" && (currRow < 0) || field[currRow, currCol] != 0)
                {
                    currRow++;
                    currCol++;
                    direction = "right";
                }


                field[currRow, currCol] = i + 1;

                if (direction == "right")
                {
                    currCol++;
                }
                else if (direction == "down")
                {
                    currRow++;
                }
                else if (direction == "left")
                {
                    currCol--;
                }
                else if (direction == "up")
                {
                    currRow--;
                }
            }



            for (int row = 0;row < sizeField; row++)
            {
                for (int col = 0;col < sizeField; col++)
                {
                    if (col == sizeField - 1)
                    {
                        Console.Write(field[row,col]);
                    }
                    else
                    {
                        Console.Write(field[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
