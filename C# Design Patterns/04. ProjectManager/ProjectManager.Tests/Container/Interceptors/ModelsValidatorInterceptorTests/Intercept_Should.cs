using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.Common.Contracts;
using ProjectManager.Container.Interceptors;

namespace ProjectManager.Tests.Container.Interceptors.ModelsValidatorInterceptorTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        public void CallInvocationsProccedMethod_WhenPassedArgumentAreValid()
        {
            // arrange
            var invocation = new Mock<IInvocation>();
            var validator = new Mock<IValidator>();

            var modesValidatorInterceptor = new ModelsValidatorInterceptor(validator.Object);

            // act
            modesValidatorInterceptor.Intercept(invocation.Object);

            // assert
            invocation.Verify(x => x.Proceed(), Times.Once);
        }

        [Test]
        public void CallValidatorsValidateMethodWithTheCorrectReturnValueFromInvocationsProccedMethod_WhenPassedArgumentAreValid()
        {
            // arrange
            var invocation = new Mock<IInvocation>();
            var validator = new Mock<IValidator>();

            object returnValue = new object();
            invocation.Setup(x => x.ReturnValue).Returns(returnValue);

            var modesValidatorInterceptor = new ModelsValidatorInterceptor(validator.Object);

            // act
            modesValidatorInterceptor.Intercept(invocation.Object);

            // assert
            validator.Verify(x => x.Validate(It.Is<object>(o => o == returnValue)));
        }
    }
}
