namespace Cosmetics.Tests.Common
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenObjIsNull_ShouldThrowNullReferenceException()
        {
            // arrange
            object obj = null;

            // act and assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfNull_WhenObjectIsNotNull_ShouldNotThrowAnException()
        {
            // arrange
            var obj = 15;

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_WhenStringInNullOrEmpty_ShouldThrowNullNullReferenceException(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenStringIsNotNullOrEMpty_ShouldNotException()
        {
            // arrange
            string text = "some random text";

            // act and assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringLengthIsValid_WhenStringLengthIsLessThanTheMinimum_ShouldThrowIndexOutOfRangeException()
        {
            // arrange
            string text = "short";
            int min = 6;
            int max = 20;

            // act and asser
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_WhenStringLengthIsMoreThanMaximum_ShouldThrowIndexOutOfRangeException()
        {
            // arrange
            string text = "some very very very long text way more than 20 symbols";
            int min = 6;
            int max = 20;

            // act and asser
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_WhenStringLengthIsValid_ShouldNotThrowException()
        {
            string text = "some text";
            int min = 5;
            int max = 9;

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text,max,min));
        }

    }
}
