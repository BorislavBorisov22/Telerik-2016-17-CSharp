namespace CohesionAndCoupling
{
    using System;

    using CohesionAndCoupling.Figures;
    using CohesionAndCoupling.Files;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameManager.GetFileExtension("example"));
            Console.WriteLine(FileNameManager.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameManager.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameManager.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameManager.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameManager.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;
            var figure3D = new Figure3D(width, height, depth);

            Console.WriteLine("Volume = {0:f2}", figure3D.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure3D.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", figure3D.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure3D.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure3D.CalcDiagonalYZ());
        }
    }
}
