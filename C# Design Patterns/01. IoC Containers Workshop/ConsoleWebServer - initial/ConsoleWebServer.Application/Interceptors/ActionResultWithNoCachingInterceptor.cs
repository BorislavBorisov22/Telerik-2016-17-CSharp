using ConsoleWebServer.Framework;
using Ninject.Extensions.Interception;

namespace ConsoleWebServer.Application.Interceptors
{
    public class ActionResultWithNoCachingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var response = invocation.ReturnValue as IHttpResponse;
            if (response != null)
            {
                response.AddHeader("Cache-Control", "private, max-age=0, no-cache");
            }
        }
    }
}
