namespace Dealership.Tests.Engine.CommandTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Engine;
    using Fakes;

    [TestFixture]
    public class CommandCosntructor_Should
    {
        [Test]
        public void InitiateParametersCollection_WhenObjectIsConstructed()
        {
            // arrange and act
            string input = "HirePilot John";
            var command = new Command(input);

            // assert
            Assert.IsNotNull(command.Parameters);
        }

        [Test]
        public void CallCommandsTranslateInputMethod_WhenObjecctIsConstructed()
        {
            // arrange and act
            string input = "HirePilot John";
            var command = new CommandFake(input);

            // assert
            Assert.IsTrue(command.IsTranslateInputCalled);
        }
    }
}
