namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using System.Collections.Generic;
    using Academy.Commands.Adding;
    using System.Linq;

    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedStudentIsAlreadyPartOfTheSeason()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string userToAddUsername = "validName";
            string seasonId = "0";

            var inputParameters = new List<string>() { userToAddUsername, seasonId };

            var studentToAdd = new Mock<IStudent>();
            studentToAdd.Setup(x => x.Username).Returns(userToAddUsername);

            var engineStudents = new List<IStudent>() { studentToAdd.Object };
            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var seasonStub = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>() { studentToAdd.Object };
            seasonStub.Setup(x => x.Students).Returns(seasonStudents);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            // act and assert
            Assert.Throws<ArgumentException>(() => command.Execute(inputParameters));
        }

        [Test]
        public void CorrecltyAddStudentToSeason_WhenPassedStudentIsNotAlreadyAPartOfTheSeason()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string userToAddUsername = "validName";
            string seasonId = "0";

            var inputParameters = new List<string>() { userToAddUsername, seasonId };

            var studentToAdd = new Mock<IStudent>();
            studentToAdd.Setup(x => x.Username).Returns(userToAddUsername);

            var engineStudents = new List<IStudent>() { studentToAdd.Object };
            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var seasonStub = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonStub.Setup(x => x.Students).Returns(seasonStudents);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            // act
            command.Execute(inputParameters);

            // assert
            Assert.AreSame(seasonStudents.First(), studentToAdd.Object);
        }

        [Test]
        public void ReturnASuccesMessageContainingSetudentsUsernameAndId_WhenStudentIsAddedToSeason()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string userToAddUsername = "validName";
            string seasonId = "0";

            var inputParameters = new List<string>() { userToAddUsername, seasonId };

            var studentToAdd = new Mock<IStudent>();
            studentToAdd.Setup(x => x.Username).Returns(userToAddUsername);

            var engineStudents = new List<IStudent>() { studentToAdd.Object };
            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var seasonStub = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonStub.Setup(x => x.Students).Returns(seasonStudents);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            // act
            var resultMessage = command.Execute(inputParameters);

            // assert
            StringAssert.Contains(userToAddUsername, resultMessage);
            StringAssert.Contains(seasonId, resultMessage);
        }
    }
}
