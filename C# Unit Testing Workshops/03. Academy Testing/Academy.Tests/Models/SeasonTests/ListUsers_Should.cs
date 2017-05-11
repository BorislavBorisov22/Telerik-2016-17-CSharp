namespace Academy.Tests.Models.SeasonTests
{
    using System;

    using NUnit.Framework;
    using Academy.Models.Enums;
    using Academy.Models;
    using Moq;
    using Academy.Models.Contracts;

    [TestFixture]
    public class ListUsers_Should
    {
        [Test]
        public void CallAllStudentsInStudentsCollectionToStringMethod_WhenCalled()
        {
            // arrange
            int starting = 2016;
            int ending = 2017;
            var initiative = Initiative.SoftwareAcademy;

            var season = new Season(starting, ending, initiative);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString());

            season.Students.Add(studentMock.Object);

            // act
            season.ListUsers();

            // assert
            studentMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void CallAllTrainersInTrainersCollectionToStringMethod_WhenCalled()
        {
            // arrange
            int starting = 2016;
            int ending = 2017;
            var initiative = Initiative.SoftwareAcademy;

            var season = new Season(starting, ending, initiative);

            var trainerMock = new Mock<ITrainer>();
            trainerMock.Setup(x => x.ToString());

            season.Trainers.Add(trainerMock.Object);

            // act
            season.ListUsers();

            // assert
            trainerMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ReturnStringContainingNoUsers_WhenNoUsersArePresentInCollections()
        {
            // arrange
            int starting = 2016;
            int ending = 2017;
            var initiative = Initiative.SoftwareAcademy;

            var season = new Season(starting, ending, initiative);

            string expectedResult = "no users";

            // act
            var result = season.ListUsers();

            // assert
            StringAssert.Contains(expectedResult, result);
        }
    }
}
