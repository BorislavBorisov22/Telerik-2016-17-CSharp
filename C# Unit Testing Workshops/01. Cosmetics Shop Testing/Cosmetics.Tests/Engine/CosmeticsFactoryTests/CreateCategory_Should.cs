namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;

    [TestFixture]
    public class CreateCategory_Should
    {
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenPassedNameIsNullOrEmpty(string name)
        {
            // arrange
            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [TestCase("s")]
        [TestCase("some very some verysome verysome verysome verysome verysome verysome very long string")]
        public void ThrowIndexOutOfRangeException_WhenPasedNameLengthIsInvalid(string name)
        {
            // arrange
            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }
    }
}
