using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.CreateStudentCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void CallStudentFactoryCreateMethodWithValidParameters_WhenPassedArgumentAreValid()
        {
            // arrange
            var studentFactory = new Mock<IStudentFactory>();
            var schoolSystemData = new Mock<ISchoolSystemData>();

            IList<string> commandParams = new List<string>()
            {
                "Ivan",
                "Ivanov",
                "5"
            };

            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Fifth;

            var student = new Mock<IStudent>();
            student.Setup(x => x.FirstName).Returns(firstName);
            student.Setup(x => x.LastName).Returns(lastName);
            student.Setup(x => x.Grade).Returns(grade);

            studentFactory.Setup(x => x.CreateStudent(firstName, lastName, grade)).Returns(student.Object);

            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, schoolSystemData.Object);
            // act
            createStudentCommand.Execute(commandParams);

            // assert
            studentFactory.Verify(x => x.CreateStudent(firstName, lastName, grade), Times.Once);
        }

        [Test]
        public void CallSchoolSystemDataWithCorrectParameters_WhenPassedArgumentsAreValid()
        {
            // arrange
            var studentFactory = new Mock<IStudentFactory>();
            var schoolSystemData = new Mock<ISchoolSystemData>();

            IList<string> commandParams = new List<string>()
            {
                "Ivan",
                "Ivanov",
                "5"
            };

            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Fifth;

            var student = new Mock<IStudent>();
            student.Setup(x => x.FirstName).Returns(firstName);
            student.Setup(x => x.LastName).Returns(lastName);
            student.Setup(x => x.Grade).Returns(grade);

            studentFactory.Setup(x => x.CreateStudent(firstName, lastName, grade)).Returns(student.Object);

            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, schoolSystemData.Object);
            // act
            createStudentCommand.Execute(commandParams);

            // assert
            schoolSystemData.Verify(x => x.AddStudent(0, student.Object), Times.Once);
        }

        [Test]
        public void ReturnCorrectMessage_WhenStudentHasBeenAddedSuccessfully()
        {
            // arrange
            var studentFactory = new Mock<IStudentFactory>();
            var schoolSystemData = new Mock<ISchoolSystemData>();

            IList<string> commandParams = new List<string>()
            {
                "Ivan",
                "Ivanov",
                "5"
            };

            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Fifth;

            var student = new Mock<IStudent>();
            student.Setup(x => x.FirstName).Returns(firstName);
            student.Setup(x => x.LastName).Returns(lastName);
            student.Setup(x => x.Grade).Returns(grade);

            studentFactory.Setup(x => x.CreateStudent(firstName, lastName, grade)).Returns(student.Object);

            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, schoolSystemData.Object);

            string expectedMessage = $"A new student with name {firstName} {lastName}, grade {grade} and ID {0} was created.";

            // act
            string actualMessage = createStudentCommand.Execute(commandParams);

            // assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }
    }
}
