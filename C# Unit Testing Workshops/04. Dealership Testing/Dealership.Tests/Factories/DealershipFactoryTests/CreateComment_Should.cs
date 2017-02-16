namespace Dealership.Tests.Factories.DealershipFactoryTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Factories;
    using Dealership.Models;

    [TestFixture]
    public class CreateComment_Should
    {
        [Test]
        public void ReturnInstanceOfCommnet_WhenPassedPArametersAreValid()
        {
            // arrange
            string content = "some contest";

            var factory = new DealershipFactory();

            // act
            var returnedObj = factory.CreateComment(content);

            // assert
            Assert.IsInstanceOf<Comment>(returnedObj);
        }
    }
}
