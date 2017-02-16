namespace Dealership.Tests.Models.UserTests
{
    using Dealership.Common.Enums;
    using Dealership.Contracts;
    using Dealership.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RemoveComment_Should
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
        public void ThrowArgumentNullException_WhenCommentToRemoveIsNull()
        {
            // arrange
            IComment comment = null;
            var vehicleStub = new Mock<IVehicle>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => this.user.RemoveComment(comment, vehicleStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenVehicleToRemoveCommentIsNull()
        {
            // arrange
            var commentStub = new Mock<IComment>();
            IVehicle vehicleStub = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => this.user.RemoveComment(commentStub.Object, vehicleStub));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIsNotTHeAuthorOfTheCommnet()
        {
            // arrange
            string commentAuthor = "Vaniusha";
            var commentStub = new Mock<IComment>();
            commentStub.Setup(x => x.Author).Returns(commentAuthor);

            var vehicleStub = new Mock<IVehicle>();

            // act and arrange
            Assert.Throws<ArgumentException>(() => this.user.RemoveComment(commentStub.Object, vehicleStub.Object));
        }

        [Test]
        public void hrowArgumentException_whenUserIsNotTheCommnetsAuthor()
        {
            // arrange
            string author = "Some Othre";

            var commentStub = new Mock<IComment>();
            var vehicleStub = new Mock<IVehicle>();

            commentStub.Setup(x => x.Author).Returns(author);

            // act and assert
            Assert.Throws<ArgumentException>(() => this.user.RemoveComment(commentStub.Object, vehicleStub.Object));
        }

        [Test]
        public void RemoveCommentSuccessfully_WhenUserIsTheAuthorOfTheComment()
        {
            // arrange
            string author = "validName";
            var commentStub = new Mock<IComment>();
            var vehicleMock = new Mock<IVehicle>();

            commentStub.Setup(x => x.Author).Returns(author);

            var commentsList = new List<IComment>() { commentStub.Object };

            vehicleMock.Setup(x => x.Comments).Returns(commentsList);

            // act
            this.user.RemoveComment(commentStub.Object, vehicleMock.Object);

            // assert
            Assert.AreEqual(0, vehicleMock.Object.Comments.Count);
        }
    }
}
