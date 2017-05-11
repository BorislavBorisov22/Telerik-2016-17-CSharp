namespace SchoolSystem.Tests.Models.Student
{
    using System;

    using NUnit.Framework;
    using Moq;
    using SchoolSystem.Models;
    using SchoolSystem.Enum;

    class ListMarks_Should
    {
        [Test]
        public void ReturnAStringContainingNoMarks_WhenStudentHasNoMarks()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            Grade grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);
            string expected = "no marks";
            
            // act
            string marksString = student.ListMarks();

            // assert
            StringAssert.Contains(expected, marksString);
        }

        [Test]
        public void ReturnAStringContainingTheseMarks_WhenStudentHasMarksInMarksList()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            Grade grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);

            var mark = new Mock<Contracts.IMark>();
            student.Marks.Add(mark.Object);

            string expected = "these marks";

            // act
            string marksString = student.ListMarks();

            // assert
            StringAssert.Contains(expected, marksString);
        }

        [Test]
        public void ReturnAStringContainingTheMarksValueAndSubject_WhenStudentHasOneMarkPresent()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            Grade grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);

            var mark = new Mock<Contracts.IMark>();
            mark.Setup(x => x.Subject).Returns(Enums.Subject.Math);
            mark.Setup(x => x.Value).Returns(5);

            student.Marks.Add(mark.Object);

            string expectedValue = "5";
            string expectedSubject = "Math";

            // act
            string marksString = student.ListMarks();

            // assert
            StringAssert.Contains(expectedValue, marksString);
            String.Concat(expectedSubject, marksString);
        }
    }
}
