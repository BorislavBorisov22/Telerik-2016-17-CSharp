namespace PackageManager.Tests.Models.PackageTests
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class SetName_Should
    {
        [Test]
        public void SetNameCorrectly_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            // act
            var package = new Package(name, versionStub.Object);

            // assert
            Assert.AreEqual(name, package.Name);
        }
    }
}
