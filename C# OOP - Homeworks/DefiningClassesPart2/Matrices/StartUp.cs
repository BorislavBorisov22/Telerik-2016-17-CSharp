namespace Matrices
{
    using System;

    public class StartUp
    {
        public static void FillMatrixRandomly(Matrix<int> matrix)
        {
            var rng = new Random();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = rng.Next(0, 25);
                }
            }
        }

        public static void Main()
        {
            var firstMatrix = new Matrix<int>(3, 3);
            FillMatrixRandomly(firstMatrix);
            Console.WriteLine("First Matrix:");
            Console.WriteLine(firstMatrix);
            Console.WriteLine("-----------------------");
            var secondMatrix = new Matrix<int>(3, 3);
            FillMatrixRandomly(secondMatrix);
            Console.WriteLine("Second Matrix:");
            Console.WriteLine(secondMatrix);
            Console.WriteLine("------------------------");

            var addedMatrix = firstMatrix + secondMatrix;
            Console.WriteLine("Added matrices result:\n\r{0}", addedMatrix);
            Console.WriteLine("-------------------------");

            var substractetMatrix = firstMatrix - secondMatrix;
            Console.WriteLine("Substracted matrices result:\n\r{0}", substractetMatrix);
            Console.WriteLine("-----------------");
            firstMatrix = new Matrix<int>(2, 3);
            FillMatrixRandomly(firstMatrix);

            secondMatrix = new Matrix<int>(3, 2);
            FillMatrixRandomly(secondMatrix);

            var multipliedMatrix = firstMatrix * secondMatrix;
            Console.WriteLine("First Matrix to be used for multiplication:\n\r{0}", firstMatrix);
            Console.WriteLine("--------------------");
            Console.WriteLine("Second Matrix to be used for multiplication:\n\r{0}", secondMatrix);
            Console.WriteLine("--------------------");
            Console.WriteLine("Multiplication matrices result:\n\r{0}", multipliedMatrix);

            var zeroMatrix = new Matrix<decimal>(3, 3);

            // zeroMatrix[0, 0] = 1; remove comment to see 
            // if the output changes for the zero matrix conditional statements
            Console.WriteLine("\nMatrix filled with zeros");
            Console.WriteLine(zeroMatrix);

            if (zeroMatrix)
            {
                Console.WriteLine("Matrix contains non-zero element");
            }
            else
            {
                Console.WriteLine("Matrix does not contain non-zero element");
            }
        }
    }
}
