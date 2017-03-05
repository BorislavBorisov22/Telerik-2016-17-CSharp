namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Exceptions;

    [TestFixture]
    public class UnitsFactoryTests
    {
        private UnitsFactory factory;

        [SetUp]
        public void InstanceFactory()
        {
            this.factory = new UnitsFactory();
        }

        [TestCase("create unit Procyon Gosho 1")]
        [TestCase("create unit Procyon Ivan 2")]
        public void GetUnit_WhenValidCommandForProcyonCreation_ShouldReturnNewProcyon(string command)
        {
            var returnedInstance = this.factory.GetUnit(command);

            Assert.IsInstanceOf<Procyon>(returnedInstance);
        }

        [TestCase("create unit Luyten Pesho 1")]
        [TestCase("create unit Luyten Tosho 2")]
        public void GetUnit_WhenValidCommandForLuytenCreation_ShouldReturnNewLuyten(string command)
        {
            var returnedInstance = this.factory.GetUnit(command);

            Assert.IsInstanceOf<Luyten>(returnedInstance);
        }

        [TestCase("create unit Lacaille Vancho 1")]
        [TestCase("create unit Lacaille Penka 15")]
        public void GetUnit_WhenValidCommandForLacailleCreation_WhouldReturnNewLacaille(string command)
        {
            var returnedInstace = this.factory.GetUnit(command);

            Assert.IsInstanceOf<Lacaille>(returnedInstace);
        }

        [TestCase("invalid command")]
        [TestCase("create unit InvalidUnit Pesho 4")]
        public void GetUnit_WhenPassedCommandIsInInvalidFormat_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            Assert.Throws<InvalidUnitCreationCommandException>(() => this.factory.GetUnit(command));
        }

        [Test]
        public void GetUnit_WhenPassedCommandIsInInvalidFormat_ShouldThrowInvalidUnitCreationCommandExceptionWithCorrectMessage()
        {
            try
            {
                this.factory.GetUnit("invalid command");
            }
            catch(InvalidUnitCreationCommandException ex)
            {
                Assert.IsTrue(ex.Message.Contains("IntergalacticTravel.Exceptions"));
            }
        }
    }
}
