using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Data.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.RemoveStudentCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private readonly IList<string> parameters = new List<string>() { "5" };

        [Test]
        public void CallSchoolSystemDataWithCorrectId_WhenPassedArgumentAreCorrect()
        {
            // arrange
            var schoolSystemData = new Mock<ISchoolSystemData>();
            var removeStudentCommand = new RemoveStudentCommand(schoolSystemData.Object);

            // act
            removeStudentCommand.Execute(this.parameters);

            // assert
            schoolSystemData.Verify(x => x.RemoveStudent(5), Times.Once);
        }

        [Test]
        public void ReturnCorrectMessage_WhenStudentHasBeenRemovedSuccessfully()
        {
            // arrange
            var schoolSystemData = new Mock<ISchoolSystemData>();
            var removeStudentCommand = new RemoveStudentCommand(schoolSystemData.Object);

            string expectedMessage = "Student with ID 5 was sucessfully removed.";

            // act
            string actualMessage = removeStudentCommand.Execute(this.parameters);

            // assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }
    }
}
