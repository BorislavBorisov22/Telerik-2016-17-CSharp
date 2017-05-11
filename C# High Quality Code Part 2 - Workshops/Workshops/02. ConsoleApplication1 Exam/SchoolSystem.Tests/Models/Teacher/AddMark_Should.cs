namespace SchoolSystem.Tests.Models.Teacher
{
    using SchoolSystem.Models;
    using SchoolSystem.Contracts;
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class AddMark_Should
    {
        [Test]
        public void CallStudentsMarksAddOnce_WhenPassedParametersAreValid()
        {
            // arrange
            var firstName = "Ivan";
            var lastName = "Ivanov";
            var subject = 3;

            var teacher = new Teacher(firstName, lastName, subject);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            // act
            float markValue = 3;
            teacher.AddMark(studentMock.Object, markValue);

            // assert
            studentMock.Verify(x => x.Marks.Add(It.IsAny<IMark>()), Times.Once);
        }

        [Test]
        public void CallStudentsMarksAddWithTheCorrectPassedMarkValue_WhenPassedParametersAreValid()
        {
            // arrange
            var firstName = "Ivan";
            var lastName = "Ivanov";
            var subject = 3;

            var teacher = new Teacher(firstName, lastName, subject);
            float markValue = 3;

            var studentMock = new Mock<IStudent>();
            studentMock
                .Setup(x => x.Marks.Add(It.Is<IMark>(y => y.Value == markValue)))
                .Verifiable();

            // act
            teacher.AddMark(studentMock.Object, markValue);

            // assert
            studentMock.Verify();
        }
    }
}
