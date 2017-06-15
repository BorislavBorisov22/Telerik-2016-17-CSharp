using Moq;
using NUnit.Framework;
using ProjectManager.Common.Contracts;
using ProjectManager.Container.Interceptors;
using System;

namespace ProjectManager.Tests.Container.Interceptors.ModelsValidatorInterceptorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassValidatorIsNull()
        {
            // arrange and act and assert
            Assert.Throws<ArgumentNullException>(() => new ModelsValidatorInterceptor(null));
        }

        [Test]
        public void NotThrow_WhenPassedValidatorIsValid()
        {
            // arrange and act and assert
            Assert.DoesNotThrow(() => new ModelsValidatorInterceptor(new Mock<IValidator>().Object));
        }
    }
}
