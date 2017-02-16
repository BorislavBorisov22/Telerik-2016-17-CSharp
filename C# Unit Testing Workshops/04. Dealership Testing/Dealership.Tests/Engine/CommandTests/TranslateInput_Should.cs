namespace Dealership.Tests.Engine.CommandTests
{
    using Dealership.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class TranslateInput_Should
    {
        [Test]
        public void CorrectlyAssingNameOfCommand_WhenPassedInputIsInValidFormat()
        {
            // arrange and act
            string input = "HirePilot John";
            var command = new Command(input);

            string expectedName = "HirePilot";
            // asssert
            Assert.AreEqual(expectedName, command.Name);
        }

        [Test]
        public void AddParametersCorrectly_WhenAllPassedParametersAreValidSeparatedBySpaces()
        {
            // arrange
            string input = "CommnadName Parameter1 Parameter2 Parameter3";
            var command = new Command(input);

            string expected = "Parameter1, Parameter2, Parameter3";
            // act
            string returnedParameters = string.Join(", ", command.Parameters);

            // assert
            Assert.AreEqual(expected, returnedParameters);
        }

        [Test]
        public void AddParametersCorrectly_WhenPassedParametersContainCommnetSymbols()
        {
            // arrange
            string input = "CommnadName {{Parameter1 and some text here}} Parameter3";
            var command = new Command(input);

            string expected = "Parameter1 and some text here, Parameter3";

            // act
            string returnedParameters = string.Join(", ", command.Parameters);

            // assert
            Assert.AreEqual(expected, returnedParameters);
        }
    }
}
