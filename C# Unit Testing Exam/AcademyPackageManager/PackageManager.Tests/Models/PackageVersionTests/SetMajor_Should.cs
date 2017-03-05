namespace PackageManager.Tests.Models.PackageVersionTests
{
    using Enums;
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class SetMajor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedMajorIsInInvalidTRange()
        {
            // arrange
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;
            int invalidMajor = -1;

            // act and assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(invalidMajor, minor, patch, versionType));
        }

        [Test]
        public void AssignToMajorCorrectly_WhenPassedMajorRangeIsValid()
        {
            // arrange
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;
            int validMajor = 1;

            // act
            var package =  new PackageVersion(validMajor, minor, patch, versionType);

            // assert
            Assert.AreEqual(package.Major, validMajor);
        }
    }
}
