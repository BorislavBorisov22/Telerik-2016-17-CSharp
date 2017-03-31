namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {  
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
