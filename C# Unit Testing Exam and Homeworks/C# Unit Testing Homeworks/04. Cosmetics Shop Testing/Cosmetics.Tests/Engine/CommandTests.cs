namespace Cosmetics.Tests.Engine
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenInputIsInValidFormat_ShouldReturnObjectWithCommandType()
        {
            string input = "Shampoo";

            Assert.IsInstanceOf(typeof(Command),Command.Parse(input));
        }

        [Test]
        public void Parse_WhenInputStringIsInValidFormat_ShouldAssingRightValuesToNameAndParameterProperties()
        {
            string input = "Shampoo parameter1 parameter2 parameter3";

            var command = Command.Parse(input);

            Assert.AreEqual("Shampoo", command.Name);
            Assert.AreEqual("parameter1 parameter2 parameter3", string.Join(" ", command.Parameters));
        }

        [Test]
        public void Parse_WhenInputStringIsNull_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenInputStringIsNameIsNullOrEmpty_ShouldThrowArgumentNullExceptionWithaMessageThatContainsName()
        {
            string input = " Add Some Text";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));

            bool containsNameString = ex.Message.Contains("Name");

            Assert.IsTrue(containsNameString);
        }

        [Test]
        public void Parse_WhenInputStringParametersIsNullOrEmpty_ShouldThrowArgumentNullExceptionWithAMessageThatContainsList()
        {
            string input = "Add     ";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));

            bool containsListString = ex.Message.Contains("List");

            Assert.IsTrue(containsListString);
        }
    }
}
