namespace Cosmetics.Tests.Engine.CommandTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;

    [TestFixture]
    public class Parse_Should
    {
        [Test]
        public void ReturnNewCommand_WhenPassedValidInputStringFormat()
        {
            // arrange
            string inputString = "Valid Format String";

            // act
            var returnedObj = Command.Parse(inputString);

            // assert
            Assert.IsInstanceOf<Command>(returnedObj);
        }

        [Test]
        public void SetCorrectValuesToNamePropertyOfTheCommand_WhenPassedValidFormatString()
        {
            // arrange
            string inputString = "Valid Format String";
            string expectedNameOfCommand = "Valid";

            // act
            var command = Command.Parse(inputString);

            // assert
            Assert.AreEqual(expectedNameOfCommand, command.Name);
        }

        [Test]
        public void SetCorrectValuesToParametersPropertyOfTheCommand_WhenPassedValidFormatString()
        {
            // arrange
            string inputString = "Valid Format String";
            string expectedParametersOfCommand = "Format String";

            // act
            var command = Command.Parse(inputString);
            string parameters = string.Join(" ", command.Parameters);

            // assert
            Assert.AreEqual(expectedParametersOfCommand, parameters);
        }

        [Test]
        public void ThrowNullReferenceException_WhenPAssedStringISNull()
        {
            // arrange and act and assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingName_WhenTheStringThatRepresentsNameIsNullOrEmpty()
        {
            // arrange
            string inputString = "  Command Parames";
            string expectedString = "Name";

            // act
            var ex  = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputString));

            // asssert
            StringAssert.Contains(expectedString, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingList_WhenTheStringThatRepresentsParametersIsNullOrEmpty()
        {
            // arrange
            string inputString = "Name     ";
            string expectedString = "List";

            // act
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputString));

            // asssert
            StringAssert.Contains(expectedString, ex.Message);
        }
    }
}
