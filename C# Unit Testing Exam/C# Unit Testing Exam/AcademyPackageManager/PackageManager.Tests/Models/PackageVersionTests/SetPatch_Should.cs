namespace PackageManager.Tests.Models.PackageVersionTests
{
    using System;

    using NUnit.Framework;
    using Enums;
    using PackageManager.Models;

    [TestFixture]
    public class SetPatch_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedPatchIsInInvalidTRange()
        {
            // arrange
            int major = 1;
            int minor = 1;
            int invalidPatch = -3;
            var versionType = VersionType.alpha;

            // act and assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, invalidPatch, versionType));
        }

        [Test]
        public void AssignToPatchCorrectly_WhenPassedPatchRangeIsValid()
        {
            // arrange
            int major = 1;
            int minor = 2;
            int validPatch = 3;
            var versionType = VersionType.alpha;


            // act
            var package = new PackageVersion(major, minor, validPatch, versionType);

            // assert
            Assert.AreEqual(package.Patch, validPatch);
        }
    }
}
