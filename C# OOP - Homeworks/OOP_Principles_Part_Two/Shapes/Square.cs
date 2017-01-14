namespace Shapes
{
    public class Square : Shape, IShape
    {
        public Square(double side) 
            : base(side, side)
        {
        }
    }
}
