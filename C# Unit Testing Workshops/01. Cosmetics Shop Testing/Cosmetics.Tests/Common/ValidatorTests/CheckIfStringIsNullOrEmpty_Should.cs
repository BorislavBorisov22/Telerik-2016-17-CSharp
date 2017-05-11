namespace Cosmetics.Tests.Common.ValidatorTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfStringIsNullOrEmpty_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedObjectIsNull()
        {
            // arrange and act and assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));
        }

        [Test]
        public void ThrowNullReferenceException_WhenPassedObjectIsEmptyString()
        {
            // arrange and act and assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(""));
        }

        [Test]
        public void NotThrow_WhenPassedAValidString()
        {
            // arrange
            string validString = "validBro";

            // act and assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(validString));
        }
    }

}
