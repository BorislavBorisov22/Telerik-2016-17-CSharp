namespace Coordinates
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // creating two instances of the Point3D class and printing the on the console
            // to check if printing is correct
            var firstPoint = new Point3D(1.05, 2.14, 3.14);
            var secondPoint = new Point3D(17, 6, 2);
            Console.WriteLine(firstPoint);
            Console.WriteLine(secondPoint);

            // calculating distance between the two points using the static class DistanceCalculator
            // according to online 3D distance calculator distance should be 16.449976
            // with precision of six digits after the decimal point
            var distance = DistanceCalculator.CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine("Distance between the two points: {0:f6}", distance);

            // create an instance of the class path try to print add some point in it
            // and output them on the console
            var thirdPoint = new Point3D(12, 12, 12);
            var totalPoints = new Path();
            totalPoints.AddPoint(firstPoint);
            totalPoints.AddPoint(secondPoint);
            totalPoints.AddPoint(thirdPoint);
        
            Console.WriteLine(totalPoints);
            Console.WriteLine();

            // use the static method SavePath() in PathStorage class to try and save a given path in a text
            // file. The result of the method should be saved in save.txt in the "coordinates"
            // folder
            PathStorage.SavePath(totalPoints, @"..\..\SavedPoints.txt");

            // use static method LoadPath to load a sequence of points and add them to an
            // instance of the Path class
            var loadedPath = PathStorage.LoadPath(@"..\..\PointsToLoad.txt");
            Console.WriteLine();
            Console.WriteLine(loadedPath);
        }
    }
}
