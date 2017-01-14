namespace Shapes
{
    public class Triangle : Shape, IShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return base.CalculateSurface() / 2;
        }
    }
}
