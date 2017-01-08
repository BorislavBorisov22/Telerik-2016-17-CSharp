namespace Coordinates
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double firstDimensionPow = (firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X);
            double secondDimensionPow = (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y);
            double thirdDimensionPow = (firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z);

            double resultDistance = Math.Sqrt(firstDimensionPow + secondDimensionPow + thirdDimensionPow);
           
            return resultDistance;
        }
    }
}
