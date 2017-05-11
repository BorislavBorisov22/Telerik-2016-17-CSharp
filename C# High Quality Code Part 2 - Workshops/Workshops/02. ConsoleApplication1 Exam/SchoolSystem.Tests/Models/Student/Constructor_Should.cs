namespace SchoolSystem.Tests.Models.Student
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using SchoolSystem.Models;
    using SchoolSystem.Enum;



    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetMarksToANewIListInstance_WhenObjectIsContructed()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            Grade grade = Grade.Ninth;

            // act
            var student = new Student(firstName, lastName, grade);

            // assert
            Assert.AreEqual(student.Marks.Count, 0);
            Assert.IsInstanceOf<IList<Contracts.IMark>>(student.Marks);
        }

        [Test]
        public void SetGradeCorreclty_WhenObjectIsContructed()
        {
            // arrange
            string firstName = "validName";
            string lastName = "validName";
            Grade grade = Grade.Ninth;

            // act
            var student = new Student(firstName, lastName, grade);

            // assert
            Assert.AreEqual(student.Grade, grade);
        }
    }
}
