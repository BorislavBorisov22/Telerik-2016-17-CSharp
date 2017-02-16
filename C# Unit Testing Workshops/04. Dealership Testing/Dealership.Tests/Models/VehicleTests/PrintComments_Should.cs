namespace Dealership.Tests.Models.VehicleTests
{
    using System;

    using NUnit.Framework;
    using Common.Enums;
    using Fakes;
    using Moq;
    using Contracts;

    [TestFixture]
    public class PrintComments_Should
    {
        [Test]
        public void ShouldCallToStringToAllCommentsInCollection_WhenCalled()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            var commentMock = new Mock<IComment>();
            commentMock.Setup(x => x.ToString());
            vehicle.Comments.Add(commentMock.Object);

            // act
            vehicle.PrintComments();

            // assert
            commentMock.Verify(x => x.ToString(), Times.Once); 
        }

        [Test]
        public void ShouldReturnStringContainingNoComments_WhenNoCommentsInCollection()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            string expectedString = "NO COMMENTS";
            // act
            var resultString = vehicle.PrintComments();

            // assert
            StringAssert.Contains(expectedString, resultString);
        }
    }
}
