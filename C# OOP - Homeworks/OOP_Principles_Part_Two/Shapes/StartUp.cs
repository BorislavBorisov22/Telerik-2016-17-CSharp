namespace Shapes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            TestShapesSurfaces();
        }

        public static void TestShapesSurfaces()
        {
            Shape[] shapes =
            {
                new Triangle(10, 5),
                new Rectangle(11, 4),
                new Rectangle(3, 5),
                new Square(4.5),
                new Square(10),
                new Triangle(3, 8),
                new Rectangle(12, 5),
                new Square(5),
                new Triangle(4, 13)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} -> {1:F2}", shape.GetType(), shape.CalculateSurface());
            }
        }
    }
}
