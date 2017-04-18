namespace RotatingMatrix.Contracts
{
    public interface IPrinter
    {
        void PrintMatrix<T>(T[,] matrix);
    }
}