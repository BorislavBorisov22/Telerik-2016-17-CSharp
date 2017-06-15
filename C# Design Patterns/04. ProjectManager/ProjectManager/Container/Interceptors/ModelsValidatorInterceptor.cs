using Bytes2you.Validation;
using Ninject.Extensions.Interception;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Container.Interceptors
{
    public class ModelsValidatorInterceptor : IInterceptor
    {
        private readonly IValidator validator;

        public ModelsValidatorInterceptor(IValidator validator)
        {
            Guard.WhenArgument(validator, "validator").IsNull().Throw();

            this.validator = validator;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            this.validator.Validate(invocation.ReturnValue);
        }
    }
}
