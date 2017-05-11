namespace SchoolSystem.Tests.Models.Person
{
    using System;

    using NUnit.Framework;
    using SchoolSystem.Models;
    using Moq;
    using SchoolSystem.Contracts;
    using SchoolSystem.Tests.Models.Person.Fakes;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedFirstNameHasInvalidLength()
        {
            // arrange
            string firstName = string.Empty;
            string lastName = "ValiName";

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person(firstName, lastName));
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedLastNameHasInvalidLength()
        {
            // arrange
            string firstName = "ValiName";
            string lastName = string.Empty;

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person(firstName, lastName));
        }


        [Test]
        public void ThrowArgumentException_WhenPassedFirstNameHasnvalidSymbols()
        {
            // arrange
            string firstName = "``````";
            string lastName = "ValiName";

            // act and assert
            Assert.Throws<ArgumentException>(() => new Person(firstName, lastName));
        }
        [Test]
        public void ThrowArgumentException_WhenPassedLastNameHasnvalidSymbols()
        {
            // arrange
            string firstName = "ValiName";
            string lastName = "``````";

            // act and assert
            Assert.Throws<ArgumentException>(() => new Person(firstName, lastName));
        }

        [Test]
        public void SetValidatorToThePassedValidator_WhenPassedValidtorIsValid()
        {
            // arrange
            string firstName = "ValidName";
            string lastName = "ValidName";
            var validator = new Mock<IValidator>();

            // act
            var person = new FakePerson(firstName, lastName, validator.Object);

            // assert
            Assert.AreSame(validator.Object, person.ValidatorExposed);
        }

        [Test]
        public void SetValidatorToNewValidator_WhenPassedValidatorIsValid()
        {
            // arrange
            string firstName = "ValidName";
            string lastName = "ValidName";

            // act 
            var person = new FakePerson(firstName, lastName);

            // assert
            Assert.IsInstanceOf<Validator>(person.ValidatorExposed);
        }
    }
}
