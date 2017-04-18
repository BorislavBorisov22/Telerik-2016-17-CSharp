namespace RotatingMatrix
{
    using Contracts;
    using Models;

    public class RotatingMatrixStartUp
    {
        public static void Start(IMatrixGenerator matrixGenerator, IWriter writer, IReader reader, IPrinter printer)
        {
            writer.WriteLine("Enter a positive number ");
            string input = reader.ReadLine();

            int matrixSize = 0;
            while (!int.TryParse(input, out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                writer.WriteLine("You haven't entered a correct positive number");
                input = reader.ReadLine();
            }

            var generator = new MatrixGenerator();

            var matrix = matrixGenerator.Generate(matrixSize);
            printer.PrintMatrix(matrix);
        }

        public static void Main()
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IPrinter printer = new Printer(writer);

            IMatrixGenerator matrixGenerator = new MatrixGenerator();

            Start(matrixGenerator, writer, reader, printer);
        }
    }
}