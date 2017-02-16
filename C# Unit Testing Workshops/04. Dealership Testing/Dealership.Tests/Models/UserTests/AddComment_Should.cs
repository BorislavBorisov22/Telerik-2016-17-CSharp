namespace Dealership.Tests.Models.UserTests
{
    using Common.Enums;
    using Contracts;
    using Dealership.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AddComment_Should
    {
        private IUser user;

        [SetUp]
        public void InitiateValidUser()
        {
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            this.user = new User(username, firstName, lastName, password, role);
        }

        [Test]
        public void ThrowArgumentNullException_WhenCommentToAddIsNull()
        {
            // arrange
            IComment commentToAdd = null;
            var vehicleToAddComment = new Mock<IVehicle>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => this.user.AddComment(commentToAdd, vehicleToAddComment.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenVehicleToAddCommentIsNull()
        {
            // arrange
            var commentToAdd = new Mock<IComment>();
            IVehicle vehicleToAddComment = null;
            // act and assert
            Assert.Throws<ArgumentNullException>(() => this.user.AddComment(commentToAdd.Object, vehicleToAddComment));
        }

        [Test]
        public void AddToVechiclesCommentsRespectiveComment_WhenPassedParametersAreValid()
        {
            // arrange
            var commentToAddStub = new Mock<IComment>();
            var vehicleToAddCommentStub = new Mock<IVehicle>();

            var vehicleComments = new List<IComment>();
            vehicleToAddCommentStub.Setup(x => x.Comments).Returns(vehicleComments);

            // act
            this.user.AddComment(commentToAddStub.Object, vehicleToAddCommentStub.Object);

            // assert
            Assert.AreSame(commentToAddStub.Object, vehicleToAddCommentStub.Object.Comments[0]); 
        }
    }
}
