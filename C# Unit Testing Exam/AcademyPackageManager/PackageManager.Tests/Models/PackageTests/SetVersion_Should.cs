namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using PackageManager.Models.Contracts;
    using PackageManager.Models;

    [TestFixture]
    public class SetVersion_Should
    {
        [Test]
        public void SetVersionCorreclty_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            // act
            var package = new Package(name, versionStub.Object);

            // assert
            Assert.AreSame(versionStub.Object, package.Version);
        }
    }
}
