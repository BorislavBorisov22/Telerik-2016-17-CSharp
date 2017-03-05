namespace PackageManager.Tests.Models.PackageVersionTests
{
    using System;

    using NUnit.Framework;
    using Enums;
    using PackageManager.Models;

    [TestFixture]
    public class SetVersionType_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedPatchIsInInvalidTRange()
        {
            // arrange
            int major = 1;
            int minor = 1;
            int patch = 3;
            var versionType = (VersionType)15;

            // act and assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void AssignToPatchCorrectly_WhenPassedPatchRangeIsValid()
        {
            // arrange
            int major = 1;
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;


            // act
            var package = new PackageVersion(major, minor, patch, versionType);

            // assert
            Assert.AreEqual(package.VersionType, versionType);
        }
    }
}
