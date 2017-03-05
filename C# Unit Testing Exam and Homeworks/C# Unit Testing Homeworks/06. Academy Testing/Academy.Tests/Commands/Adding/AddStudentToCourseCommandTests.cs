namespace Academy.Tests.Commands.Adding
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Constructor_WhenAPassedProviderIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, null));
        }

        [Test]
        public void Constructor_WhenPassedValidParameters_ShouldAssignThemCorrectly()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // act and assert
            Assert.AreSame(command.Engine, engineStub.Object);
            Assert.AreSame(command.Factory, factoryStub.Object);
        }

        [Test]
        public void Execute_WhenPassedFormIsInvalid_ShouldThrowArgumentException()
        {
            string username = "username";
            string seasonId = "0";
            string courseId = "0";
            string form = "invalidform";

            var parameters = new List<string>()
            {
                username,
                seasonId,
                courseId,
                form
            };

            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            var courseStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(courseStudents);
            courseStub.Setup(x => x.OnsiteStudents).Returns(courseStudents);
            
            var seasonCourses = new List<ICourse>() { courseStub.Object };
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);
            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_WhenAllParametersAreValidAndFormIsOnline_ShouldAddStudentToCoursesOnlineStudens()
        {
            string username = "username";
            string seasonId = "0";
            string courseId = "0";
            string form = "online";

            var parameters = new List<string>()
            {
                username,
                seasonId,
                courseId,
                form
            };

            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            var courseStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(courseStudents);
            courseStub.Setup(x => x.OnsiteStudents).Returns(courseStudents);

            var seasonCourses = new List<ICourse>() { courseStub.Object };
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);
            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            command.Execute(parameters);

            Assert.AreSame(courseStub.Object.OnlineStudents[0], studentStub.Object);
        }

        [Test]
        public void Execute_WhenAllParametersAreValidAndFormIsOnsite_ShouldAddStudentToCoursesOnsiteStudens()
        {
            string username = "username";
            string seasonId = "0";
            string courseId = "0";
            string form = "onsite";

            var parameters = new List<string>()
            {
                username,
                seasonId,
                courseId,
                form
            };

            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            var courseStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(courseStudents);
            courseStub.Setup(x => x.OnsiteStudents).Returns(courseStudents);

            var seasonCourses = new List<ICourse>() { courseStub.Object };
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);
            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            command.Execute(parameters);

            Assert.AreSame(courseStub.Object.OnsiteStudents[0], studentStub.Object);
        }

        [Test]
        public void Execute_WhenAllPassedParametersAreValid_ShouldReturnSuccessMessageThatContainsStudetnsIdAndUsername()
        {
            string username = "username";
            string seasonId = "0";
            string courseId = "0";
            string form = "onsite";

            var parameters = new List<string>()
            {
                username,
                seasonId,
                courseId,
                form
            };

            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentStub.Object };

            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            var courseStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(courseStudents);
            courseStub.Setup(x => x.OnsiteStudents).Returns(courseStudents);

            var seasonCourses = new List<ICourse>() { courseStub.Object };
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);
            var engineSeasons = new List<ISeason>() { seasonStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            string returnedResult = command.Execute(parameters);

            StringAssert.Contains(username,returnedResult);
            StringAssert.Contains(seasonId,returnedResult);
        }
    }
}
