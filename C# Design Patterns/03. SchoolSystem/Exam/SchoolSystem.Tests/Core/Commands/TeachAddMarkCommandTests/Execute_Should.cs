using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.TeachAddMarkCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private readonly IList<string> parameters = new List<string>()
        {
            "1",
            "5",
            "4"
        };

        [Test]
        public void CallSchoolSystemDataGetStudentWithCorrectId_WhenPassedArgumentsAreValid()
        {
            // arrange
            int teacherId = int.Parse(parameters[0]);
            int studentId = int.Parse(parameters[1]);
            float mark = float.Parse(parameters[2]);

            var student = new Mock<IStudent>();
            var teacher = new Mock<ITeacher>();

            var schoolSystemData = new Mock<ISchoolSystemData>();

            var teacherAddMarkCommand = new TeacherAddMarkCommand(schoolSystemData.Object);

            schoolSystemData
                .Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(student.Object);
            schoolSystemData
                .Setup(x => x.GetTeacher(It.IsAny<int>()))
                .Returns(teacher.Object);

            // act
            teacherAddMarkCommand.Execute(this.parameters);

            // assert
            schoolSystemData.Verify(x => x.GetStudent(studentId), Times.Once);
        }

        [Test]
        public void CallSchoolSystemDataGetTeacherWithCorrectId_WhenPassedArgumentsAreValid()
        {
            // arrange
            int teacherId = int.Parse(parameters[0]);
            int studentId = int.Parse(parameters[1]);
            float mark = float.Parse(parameters[2]);

            var student = new Mock<IStudent>();
            var teacher = new Mock<ITeacher>();

            var schoolSystemData = new Mock<ISchoolSystemData>();

            var teacherAddMarkCommand = new TeacherAddMarkCommand(schoolSystemData.Object);

            schoolSystemData
                .Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(student.Object);
            schoolSystemData
                .Setup(x => x.GetTeacher(It.IsAny<int>()))
                .Returns(teacher.Object);

            // act
            teacherAddMarkCommand.Execute(this.parameters);

            // assert
            schoolSystemData.Verify(x => x.GetTeacher(teacherId), Times.Once);
        }

        [Test]
        public void CallRetrievedTeacheAddMarkMetodWithCorrectParameters_WhenPassedArgumentsAreValid()
        {
            // arrange
            int teacherId = int.Parse(parameters[0]);
            int studentId = int.Parse(parameters[1]);
            float mark = float.Parse(parameters[2]);

            var student = new Mock<IStudent>();
            var teacher = new Mock<ITeacher>();

            var schoolSystemData = new Mock<ISchoolSystemData>();

            var teacherAddMarkCommand = new TeacherAddMarkCommand(schoolSystemData.Object);

            schoolSystemData
                .Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(student.Object);
            schoolSystemData
                .Setup(x => x.GetTeacher(It.IsAny<int>()))
                .Returns(teacher.Object);

            // act
            teacherAddMarkCommand.Execute(this.parameters);

            // assert
            teacher.Verify(x => x.AddMark(student.Object, mark), Times.Once);
        }

        [Test]
        public void ReturnCorrectMessage_WhenMarkHasBeenAddedToStudentSuccessfully()
        {
            // arrange
            int teacherId = int.Parse(parameters[0]);
            int studentId = int.Parse(parameters[1]);
            float mark = float.Parse(parameters[2]);

            var student = new Mock<IStudent>();
            var teacher = new Mock<ITeacher>();

            var schoolSystemData = new Mock<ISchoolSystemData>();

            var teacherAddMarkCommand = new TeacherAddMarkCommand(schoolSystemData.Object);

            schoolSystemData
                .Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(student.Object);
            schoolSystemData
                .Setup(x => x.GetTeacher(It.IsAny<int>()))
                .Returns(teacher.Object);

            string teacherFirstName = "Profesora";
            string teacherLastName = "Umniq";
            Subject teacherSubject = Subject.Programming;
            string studentFirstName = "Vankata";
            string studentLastName = "Petkov";

            teacher.Setup(x => x.FirstName).Returns(teacherFirstName);
            teacher.Setup(x => x.LastName).Returns(teacherLastName);
            teacher.Setup(x => x.Subject).Returns(teacherSubject);
            student.Setup(x => x.FirstName).Returns(studentFirstName);
            student.Setup(x => x.LastName).Returns(studentLastName);
           
            string expectedMessage = $"Teacher {teacherFirstName} {teacherLastName} added mark {mark} to student {studentFirstName} {studentLastName} in {teacherSubject}.";

            // act
            string actualMessage = teacherAddMarkCommand.Execute(this.parameters);

            // assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }
    }
}
