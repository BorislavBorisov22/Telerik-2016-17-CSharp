namespace SchoolSystem.Tests.Models.Mark
{
    using System;

    using SchoolSystem.Models;
    using SchoolSystem.Enums;
    using NUnit.Framework;
    using Moq;

    using System.Collections.Generic;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetSubjectCorrectly_WhenPassedParametersAreValid()
        {
            // arrange
            var subject = Subject.English;
            float value = 3;

            // act
            var mark = new Mark(subject, value);

            // assert
            Assert.AreEqual(subject, mark.Subject);
        }

        [Test]
        public void SetValueCorrectly_WhenPassedParametersAreValid()
        {
            // arrange
            var subject = Subject.English;
            float value = 3;

            // act
            var mark = new Mark(subject, value);

            // assert
            Assert.AreEqual(value, mark.Value);
        }

        [TestCase(1)]
        [TestCase(7)]
        public void ThrowArgumentOutOfRangeException_WhenPassegValueIsInInvalidRange(int value)
        {
            // arrange
            var subject = Subject.English;

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(subject, value));
        }

        [Test]
        public void SetValidatorCorrectly_WhenPassedValidtorIsValid()
        {
            // arrange
            var subject = Subject.English;
            float value = 3;
            var validator = new Mock<Contracts.IValidator>();


            // act
            var mark = new Mark(subject, value, validator.Object);

            // assert
            Assert.AreSame(validator.Object, mark.Validator);
        }

        [Test]
        public void SetValidatorToNewValidtor_WhenNoValidatorIsPassed()
        {
            // arrange
            var subject = Subject.English;
            float value = 3;

            // act
            var mark = new Mark(subject, value);

            // assert
            Assert.IsInstanceOf<Validator>(mark.Validator);
        }
    }
}
