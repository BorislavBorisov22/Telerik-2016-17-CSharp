namespace Academy.Tests.Commands.Adding.AddStudentToCourseTests.Fakes
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedCourseFormIsInvalid()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string studentToAddUsername = "validName";
            string seasonId = "0";
            string courseId = "0";
            string form = "invalid form";

            var inputParameters = new List<string>()
            {
                studentToAddUsername,
                seasonId,
                courseId,
                form
            };

            var studentToAddStub = new Mock<IStudent>();
            studentToAddStub.Setup(x => x.Username).Returns(studentToAddUsername);
            var engineStudents = new List<IStudent>() { studentToAddStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var courseStub = new Mock<ICourse>();
            var seasonCourses = new List<ICourse>() { courseStub.Object };

            var seasonStub = new Mock<ISeason>();
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // act and assert
            Assert.Throws<ArgumentException>(() => command.Execute(inputParameters));
        }

        [Test]
        public void AddStudentToOnsiteStudents_WhenPassedCourseFormIsOnsiteAndParamsAreValid()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string studentToAddUsername = "validName";
            string seasonId = "0";
            string courseId = "0";
            string form = "onsite";

            var inputParameters = new List<string>()
            {
                studentToAddUsername,
                seasonId,
                courseId,
                form
            };

            var studentToAddStub = new Mock<IStudent>();
            studentToAddStub.Setup(x => x.Username).Returns(studentToAddUsername);
            var engineStudents = new List<IStudent>() { studentToAddStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var courseStub = new Mock<ICourse>();
            var onsiteStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnsiteStudents).Returns(onsiteStudents);
            var seasonCourses = new List<ICourse>() { courseStub.Object };

            var seasonStub = new Mock<ISeason>();
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // act
            command.Execute(inputParameters);

            // assert
            Assert.AreSame(studentToAddStub.Object, onsiteStudents.First());
        }

        [Test]
        public void AddStudentToOnlineStudents_WhenPassedCourseFormIsOnlineAndParamsAreValid()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string studentToAddUsername = "validName";
            string seasonId = "0";
            string courseId = "0";
            string form = "online";

            var inputParameters = new List<string>()
            {
                studentToAddUsername,
                seasonId,
                courseId,
                form
            };

            var studentToAddStub = new Mock<IStudent>();
            studentToAddStub.Setup(x => x.Username).Returns(studentToAddUsername);
            var engineStudents = new List<IStudent>() { studentToAddStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var courseStub = new Mock<ICourse>();
            var onlineStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(onlineStudents);
            var seasonCourses = new List<ICourse>() { courseStub.Object };

            var seasonStub = new Mock<ISeason>();
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // act
            command.Execute(inputParameters);

            // assert
            Assert.AreSame(studentToAddStub.Object, onlineStudents.First());
        }

        [Test]
        public void ReturnSuccessMessageContainingStudentsIdAndSeasonId_WhenPassedCourseFormIsOnlineAndParamsAreValid()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            string studentToAddUsername = "validName";
            string seasonId = "0";
            string courseId = "0";
            string form = "online";

            var inputParameters = new List<string>()
            {
                studentToAddUsername,
                seasonId,
                courseId,
                form
            };

            var studentToAddStub = new Mock<IStudent>();
            studentToAddStub.Setup(x => x.Username).Returns(studentToAddUsername);
            var engineStudents = new List<IStudent>() { studentToAddStub.Object };

            engineStub.Setup(x => x.Students).Returns(engineStudents);

            var courseStub = new Mock<ICourse>();
            var onlineStudents = new List<IStudent>();
            courseStub.Setup(x => x.OnlineStudents).Returns(onlineStudents);
            var seasonCourses = new List<ICourse>() { courseStub.Object };

            var seasonStub = new Mock<ISeason>();
            seasonStub.Setup(x => x.Courses).Returns(seasonCourses);

            var engineSeasons = new List<ISeason>() { seasonStub.Object };
            engineStub.Setup(x => x.Seasons).Returns(engineSeasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // act
            var result = command.Execute(inputParameters);

            // assert
            StringAssert.Contains(studentToAddUsername, result);
            StringAssert.Contains("0", result);
        }
    }
}
