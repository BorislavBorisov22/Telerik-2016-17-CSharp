namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using Moq;
    using PackageManager.Models;
    using Enums;

    [TestFixture]
    public class CompareTo_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedOtherParameterIsNull()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            var package = new Package(name, versionStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenProvidedPackageHasDifferentNameThanThisName()
        {
            // arrange
            string name = "validName";
            var versionStub = new Mock<IVersion>();

            var package = new Package(name, versionStub.Object);

            var otherPackage = new Mock<IPackage>();
            string otherPackageName = "someName";
            otherPackage.Setup(x => x.Name).Returns(otherPackageName);

            // act and assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackage.Object));
        }

        [Test]
        public void ReturnMinusOne_WhenProvidedOtherPackageHasHigherVersion()
        {
            // arrange
            string name = "validName";
            var versionCurrentPackageStub = new Mock<IVersion>();

            int currentMajor = 1;
            int currentMinor = 1;
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
            int otherMajor = 5;
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
            var returnedValue = package.CompareTo(otherPackage.Object);

            // assert
            Assert.AreEqual(-1, returnedValue);
        }

        [Test]
        public void ReturnOne_WhenProvidedOtherPackageHasLowerVersion()
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
            var returnedValue = package.CompareTo(otherPackage.Object);

            // assert
            Assert.AreEqual(1, returnedValue);
        }

        [Test]
        public void ReturnZero_WhenProvidedOtherPackageHasTheSameVersion()
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
            var returnedValue = package.CompareTo(otherPackage.Object);

            // assert
            Assert.AreEqual(0, returnedValue);
        }
    }
}
