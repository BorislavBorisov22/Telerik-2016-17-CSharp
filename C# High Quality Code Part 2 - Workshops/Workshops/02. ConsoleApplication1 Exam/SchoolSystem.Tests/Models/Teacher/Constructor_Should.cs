namespace SchoolSystem.Tests.Models.Teacher
{
    using System;

    using NUnit.Framework;
    using Moq;
    using SchoolSystem.Models;
    using SchoolSystem.Enums;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedSubjectIsOurOfRange()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            int subject = 25;

            // act and assert
            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void SetTheCorrectSubject_WhenPassedSubjectIsValid()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            int subject = 3;

            // act
            var teacher = new Teacher(firstName, lastName, subject);

            // assert
            Assert.AreEqual(Subject.Programming, teacher.Subject);
        }
    }
}
