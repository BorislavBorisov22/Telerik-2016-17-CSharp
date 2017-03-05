namespace Cosmetics.Tests.Products
{
    using Cosmetics.Common;
    using Cosmetics.Products;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class ToothPasteTests
    {
        [Test]
        public void Print_WhenCalled_ShouldReturnStringInCorrectFormat()
        {
            // Arrange
            var toothpaste = new Toothpaste("Pesho", "Pesho", 10M, GenderType.Unisex, new List<string>() { "first", "second" });

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Pesho - Pesho:");
            expectedResult.AppendLine("  * Price: $10");
            expectedResult.AppendLine("  * For gender: Unisex");
            expectedResult.Append("  * Ingredients: first, second");

            // Act
            var executionResult = toothpaste.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), executionResult);
        }
    }
}
