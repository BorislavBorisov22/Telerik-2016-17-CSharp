namespace Academy.Tests.Commands.Adding
{
    using System;

    using NUnit.Framework;
    using Academy.Core.Contracts;
    using Moq;
    using Academy.Commands.Adding;
    using Academy.Models.Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void Constructor_WhenPassedFactoryIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            IAcademyFactory factory = null;
            var engineStub = new Mock<IEngine>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factory, engineStub.Object));
        }

        [Test]
        public void Constructor_WhenPassedEngineIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            var factory = new Mock<IAcademyFactory>();
            IEngine engineStub = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factory.Object, engineStub));
        }

        [Test]
        public void Constructor_WhenPassedParametersAreValid_ShouldAssignThemCorrectly()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            Assert.AreSame(engineStub.Object, command.Engine);
            Assert.AreSame(factoryStub.Object, command.Factory);
        }

        [Test]
        public void Execute_WhenPassedStudentIsAlreadyPartOfThisSeason_ShouldThrowArgumentException()
        {
            var factoryStub = new Mock<IAcademyFactory>();
            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("Username");
            var engineStudentsStub = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            seasonStub.Setup(x => x.Students).Returns(engineStudentsStub);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            var engineStub = new Mock<IEngine>();
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);
            engineStub.Setup(x => x.Students).Returns(engineStudentsStub);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            var parameters = new List<string>() { "Username", "0" };

            // act and assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_WhenStudentIsNotPresentInSeason_ShouldAddFoundStudent()
        {
            var factoryStub = new Mock<IAcademyFactory>();
            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("Username");
            var engineStudentsStub = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonStub.Setup(x => x.Students).Returns(seasonStudents);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            var engineStub = new Mock<IEngine>();
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);
            engineStub.Setup(x => x.Students).Returns(engineStudentsStub);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            var parameters = new List<string>() { "Username", "0" };

            // act
            command.Execute(parameters);

            // assert
            Assert.AreSame(studentStub.Object, seasonStub.Object.Students[0]);
        }

        [Test]
        public void Execute_WhenStudentIsAddedToSeasonCorrectly_ShouldReturnCorrectSuccessMessage()
        {
            var factoryStub = new Mock<IAcademyFactory>();
            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("Username");
            var engineStudentsStub = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonStub.Setup(x => x.Students).Returns(seasonStudents);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            var engineStub = new Mock<IEngine>();
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);
            engineStub.Setup(x => x.Students).Returns(engineStudentsStub);

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            var parameters = new List<string>() { "Username", "0" };

            // act
            string returnedValue = command.Execute(parameters);

            // assert
            StringAssert.Contains("Username", returnedValue);
            StringAssert.Contains("0", returnedValue);
        }
    }
}
