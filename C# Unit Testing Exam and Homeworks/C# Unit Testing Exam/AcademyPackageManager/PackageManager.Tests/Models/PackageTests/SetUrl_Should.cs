namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using Moq;
    using Enums;
    using PackageManager.Models;

    [TestFixture]
    public class SetUrl_Should
    {
        [Test]
        public void SetURLCorrectly_WhenOthreProvdedParametersAreValid()
        {
            // arrange
            string name = "validName";

            int versionMajor = 1;
            int versionMinor = 2;
            int versionPatch = 3;
            var versionType = VersionType.beta;
            var versionStub = new Mock<IVersion>();

            versionStub.Setup(x => x.Major).Returns(versionMajor);
            versionStub.Setup(x => x.Minor).Returns(versionMinor);
            versionStub.Setup(x => x.Patch).Returns(versionPatch);
            versionStub.Setup(x => x.VersionType).Returns(versionType);

            string expectedResult = $"{versionMajor}.{versionMinor}.{versionPatch}-{versionType}";
            
            // act
            var package = new Package(name, versionStub.Object);

            // assert
            StringAssert.Contains(expectedResult, package.Url);
        }
    }
}
