namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Exceptions;

    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyonInstance_WhenValidCorrespondingCommnadIsPassed()
        {
            // arrange
            var factory = new UnitsFactory();

            string command = "create unit Procyon Gosho 1";

            // act
            var retunredObj = factory.GetUnit(command);

            // asssert
            Assert.IsInstanceOf<Procyon>(retunredObj);
        }

        [Test]
        public void ReturnNewLuytenInstance_WhenValidCorrespondingCommnadIsPassed()
        {
            // arrange
            var factory = new UnitsFactory();

            string command = "create unit Luyten Pesho 2";

            // act
            var retunredObj = factory.GetUnit(command);

            // asssert
            Assert.IsInstanceOf<Luyten>(retunredObj);
        }

        [Test]
        public void ReturnNewLacaillleInstance_WhenValidCorrespondingCommnadIsPassed()
        {
            // arrange
            var factory = new UnitsFactory();

            string command = "create unit Lacaille Tosho 3";

            // act
            var retunredObj = factory.GetUnit(command);

            // asssert
            Assert.IsInstanceOf<Lacaille>(retunredObj);
        }

        [TestCase("create unit Procyion Pesho sdfg")]
        [TestCase("some random invalid command")]
        public void ThrowInvalidUnitCreationCommandException_WhenInvalidCommandIsPassed(string command)
        {
            // arrange
            var factory = new UnitsFactory();

            // act and assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
