namespace RotatingMatrix.Tests.Models.Printer.Fakes
{
    using System;
    using RotatingMatrix.Models;
    using RotatingMatrix.Contracts;

    public class FakePrinter : Printer
    {
        public FakePrinter(IWriter writer) 
            : base(writer)
        {
        }

        public IWriter TestWriter
        {
            get
            {
                return base.Writer;
            }
        }
    }
}
