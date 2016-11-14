using System;
using System.Text;

public class Matrix
{
    //fields
    private int[,] matrix;

    //constructor
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    //property for matrix rows
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }
    //property for matrix cols
    public int Cols
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    public object StringBulider { get; private set; }

    //overloading the indexer operator
    public int this[int row,int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }
    // overload for plus operator applied to matrices
    public static Matrix operator +(Matrix firstMatrix,Matrix secondMatrix)
    {
        Matrix resultMatrix = new Matrix(firstMatrix.Rows, firstMatrix.Cols);

        for (int row = 0; row < firstMatrix.Rows; row++)
        {
            for (int col = 0;col < firstMatrix.Cols; col++)
            {
                resultMatrix[row, col] = firstMatrix[row, col] + secondMatrix[row, col];
            }
        }

        return resultMatrix;
    }
    // overload for minus operator applied to matrices
    public static Matrix operator -(Matrix firstMatrix,Matrix secondMatrix)
    {
        Matrix resultMatrix = new Matrix(firstMatrix.Rows, firstMatrix.Cols);

        for (int row = 0; row < firstMatrix.Rows; row++)
        {
            for (int col = 0; col < firstMatrix.Cols; col++)
            {
                resultMatrix[row, col] = firstMatrix[row, col] - secondMatrix[row, col];
            }
        }

        return resultMatrix;
    }
    //overload for multiplication operator for two matrices
    public static Matrix operator *(Matrix firstMatrix,Matrix secondMatrix)
    {
        if (firstMatrix.Cols != secondMatrix.Rows)
        {
            throw new ArgumentException("First matrix columns should be equal to second matrix rows!");
        }
        Matrix resultMatrix = new Matrix(firstMatrix.Rows, secondMatrix.Cols);
        int matrixSize = firstMatrix.Rows;

        for (int row = 0;row < resultMatrix.Rows; row++)
        {
            for (int col = 0;col < resultMatrix.Cols; col++)
            {
                resultMatrix[row, col] = 0;

                for (int i = 0; i < firstMatrix.Cols; i++)
                {
                    resultMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i,col];
                }
            }
        }



        return resultMatrix;
    }


    //printing matrix
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        
        for (int row = 0;row< this.Rows; row++)
        {
            var currentLine = new StringBuilder();
            for (int col = 0; col < this.Cols; col++)
            {
                if (col == this.Cols - 1)
                {
                    currentLine.Append(this[row, col]);
                }
                else
                {
                    currentLine.Append(string.Format("{0} ", this[row, col]));
                }
            }
            result.AppendLine(currentLine.ToString());
        }


        return result.ToString();
    }


}

