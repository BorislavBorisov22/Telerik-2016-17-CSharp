namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using System.Collections.Generic;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetDependenciesCorreclty_WhenOptionalParameterIsUsed()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            // act
            var package = new Package(name, versionStub.Object);

            // assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetDependenciesCorrectly_WhenDependenciesAreProvidedAsParameter()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();
            var dependencies = new List<IPackage>();

            // act
            var package = new Package(name, versionStub.Object, dependencies);

            // assert
            Assert.AreSame(dependencies, package.Dependencies);
        }
    }
}
