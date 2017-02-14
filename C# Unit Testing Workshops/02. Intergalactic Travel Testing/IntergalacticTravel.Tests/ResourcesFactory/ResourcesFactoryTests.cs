namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        //private IResourcesFactory factory;

        //[SetUp]
        //public void InstanceFactory()
        //{
        //    this.factory = new ResourcesFactory();
        //}

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]

        public void GetResources_WhenCommandHasValidParameters_ShouldReturnANewREsourcesWithCorrespondingPropertiesValues(string command)
        {
            // arrange
            int expectedGold = 20;
            int expectedSilver = 30;
            int expectedBronze = 40;
            var factory = new ResourcesFactory();

            // act
            var returnedObject = factory.GetResources(command);

            // assert
            Assert.IsInstanceOf<Resources>(returnedObject);
            Assert.AreEqual(expectedGold, returnedObject.GoldCoins);
            Assert.AreEqual(expectedSilver, returnedObject.SilverCoins);
            Assert.AreEqual(expectedBronze, returnedObject.BronzeCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("create resources bronze(40) silver(30) gold(asdf)")]
        public void GetResources_WhenInvalidCommandIsPassed_ShouldThrowInvalidOperationException(string command)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("create resources bronze(40) silver(30) gold(asdf)")]
        public void GetResources_WhenInvalidCommandIsPassed_ShouldThrowInvalidOperationExceptionWithMessageThatContainsTheStringCommand(string command)
        {
            var factory = new ResourcesFactory();

            try
            {
                factory.GetResources(command);
            }
            catch (InvalidOperationException ioex)
            {
                Assert.IsTrue(ioex.Message.Contains("command"));
            }
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_WhenCommandIsValidButAnyValueIsLagrerThenUintMaxValue_ShouldThrowOverflowException(string command)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
