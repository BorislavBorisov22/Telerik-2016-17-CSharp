namespace RotatingMatrix.Tests.Models.Printer
{
    using System;

    using NUnit.Framework;
    using Moq;
    using RotatingMatrix.Models;
    using Fakes;
    using RotatingMatrix.Contracts;

    [TestFixture]
    public class PrinterConstructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedWriterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Printer(null));
        }

        [Test]
        public void SetWriterCorrectly_WhenPassedAValidWriter()
        {
            // arrange and act
            var writer = new Mock<IWriter>();
            var printer = new FakePrinter(writer.Object);

            // assert
            Assert.AreSame(writer.Object, printer.TestWriter);
        }
    }
}
