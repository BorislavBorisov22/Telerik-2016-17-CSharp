namespace Cosmetics.Tests.Products
{
    using Cosmetics.Common;
    using Cosmetics.Products;
    using NUnit.Framework;
    using System.Text;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_WhenCalled_ShouldReturnStringInTheCorrectFormat()
        {
            var shampoo = new Shampoo("Gosho", "Nivea",10M, GenderType.Men, 10, UsageType.EveryDay);

            var result = new StringBuilder();

            result.AppendLine("- Nivea - Gosho:");
            result.AppendLine("  * Price: $100");
            result.AppendLine("  * For gender: Men");
            result.AppendLine("  * Quantity: 10 ml");
            result.Append("  * Usage: EveryDay");

            System.Console.WriteLine(result.ToString());
            System.Console.WriteLine(shampoo.Print());
            Assert.AreEqual(result.ToString(), shampoo.Print());
        }
    }
}
