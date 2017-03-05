namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using Moq;
    using PackageManager.Models;
    using System.Collections.Generic;
    using Enums;

    [TestFixture]
    public class Equals_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedObjectIsNull()
        {
            // arrange
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            var package = new Package(name, versionStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ThrowArgumentException_WhenProvidedPackageIsNotIPackage()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            var package = new Package(name, versionStub.Object);

            var otherPackage = new List<string>();

            // act and assert
            Assert.Throws<ArgumentException>(() => package.Equals(otherPackage));
        }

        [Test]
        public void ReturnTrue_WhenProvidedPackageIsEqualToCurrentPackage()
        {
            // arrange
            string name = "validName";
            var versionCurrentPackageStub = new Mock<IVersion>();

            int currentMajor = 2;
            int currentMinor = 20;
            int currentPatch = 1;
            var currentVersionType = VersionType.final;

            versionCurrentPackageStub.Setup(x => x.Minor).Returns(currentMinor);
            versionCurrentPackageStub.Setup(x => x.Major).Returns(currentMajor);
            versionCurrentPackageStub.Setup(x => x.Patch).Returns(currentPatch);
            versionCurrentPackageStub.Setup(x => x.VersionType)
                .Returns(currentVersionType);


            var package = new Package(name, versionCurrentPackageStub.Object);

            var otherPackage = new Mock<IPackage>();

            otherPackage.Setup(x => x.Name).Returns(name);
            otherPackage.Setup(x => x.Version).Returns(versionCurrentPackageStub.Object);

            // act
            var result = package.Equals(otherPackage.Object);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenProvidedPackageHasDifferentName()
        {
            // arrange
            string name = "validName";
            var versionCurrentPackageStub = new Mock<IVersion>();

            int currentMajor = 2;
            int currentMinor = 20;
            int currentPatch = 1;
            var currentVersionType = VersionType.final;

            versionCurrentPackageStub.Setup(x => x.Minor).Returns(currentMinor);
            versionCurrentPackageStub.Setup(x => x.Major).Returns(currentMajor);
            versionCurrentPackageStub.Setup(x => x.Patch).Returns(currentPatch);
            versionCurrentPackageStub.Setup(x => x.VersionType)
                .Returns(currentVersionType);


            var package = new Package(name, versionCurrentPackageStub.Object);

            var otherPackage = new Mock<IPackage>();

            string otherName = "otherName";
            otherPackage.Setup(x => x.Name).Returns(otherName);
            otherPackage.Setup(x => x.Version).Returns(versionCurrentPackageStub.Object);

            // act
            var result = package.Equals(otherPackage.Object);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnFalse_WhenProvidedPackageHasTheSameNameButDifferentVersionProperty()
        {

            // arrange
            string name = "validName";
            var versionCurrentPackageStub = new Mock<IVersion>();

            int currentMajor = 2;
            int currentMinor = 20;
            int currentPatch = 1;
            var currentVersionType = VersionType.final;

            versionCurrentPackageStub.Setup(x => x.Minor).Returns(currentMinor);
            versionCurrentPackageStub.Setup(x => x.Major).Returns(currentMajor);
            versionCurrentPackageStub.Setup(x => x.Patch).Returns(currentPatch);
            versionCurrentPackageStub.Setup(x => x.VersionType)
                .Returns(currentVersionType);


            var package = new Package(name, versionCurrentPackageStub.Object);

            var otherPackage = new Mock<IPackage>();
            int otherMinor = 1;
            int otherMajor = 1;
            int otherPatch = 1;
            var otherVersionType = VersionType.final;

            var otherPackageVersion = new Mock<IVersion>();
            otherPackageVersion.Setup(x => x.Minor).Returns(otherMinor);
            otherPackageVersion.Setup(x => x.Major).Returns(otherMajor);
            otherPackageVersion.Setup(x => x.Patch).Returns(otherPatch);
            otherPackageVersion.Setup(x => x.VersionType).Returns(otherVersionType);

            otherPackage.Setup(x => x.Name).Returns(name);
            otherPackage.Setup(x => x.Version).Returns(otherPackageVersion.Object);

            // act
            var returnedValue = package.Equals(otherPackage.Object);

            // assert
            Assert.IsFalse(returnedValue);
        }
    }
}
