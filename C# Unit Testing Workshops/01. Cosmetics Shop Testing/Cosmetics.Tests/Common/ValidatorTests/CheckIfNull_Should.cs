namespace Cosmetics.Tests.Common.Validator
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfNull_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedObjectIsNull()
        {
            // arrange and act and assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void NotThrow_WhenPassedObjectIsNotNull()
        {
            // arrange
            object str = "random string";

            // act and assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(str));
        }
    }
}
