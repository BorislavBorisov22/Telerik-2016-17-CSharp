namespace PackageManager.Tests.Models.PackageVersionTests
{
    using NUnit.Framework;
    using Enums;
    using System;
    using PackageManager.Models;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetMajorCorrectly_WhenObjectIsConstructedWithValidVlues()
        {
            // arrange
            int major = 5;
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;

            // act
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // assert
            Assert.AreEqual(major, packageVersion.Major);
        }

        [Test]
        public void SetMinorCorrectly_WhenObjectIsConstructedWithValidVlues()
        {
            // arrange
            int major = 5;
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;

            // act
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // assert
            Assert.AreEqual(minor, packageVersion.Minor);
        }

        [Test]
        public void SetPatchCorrectly_WhenObjectIsConstructedWithValidVlues()
        {
            // arrange
            int major = 5;
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;

            // act
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // assert
            Assert.AreEqual(patch, packageVersion.Patch);
        }

        [Test]
        public void SetVersionTypeCorrectly_WhenObjectIsConstructedWithValidVlues()
        {
            // arrange
            int major = 5;
            int minor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;

            // act
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // assert
            Assert.AreEqual(versionType, packageVersion.VersionType);
        }
    }
}
