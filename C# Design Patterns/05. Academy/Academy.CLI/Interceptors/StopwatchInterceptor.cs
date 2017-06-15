using System;
using Ninject.Extensions.Interception;
using System.Diagnostics;
using Academy.Core.Contracts;

namespace Academy.CLI.Interceptors
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public StopwatchInterceptor(IWriter writer)
        {
            this.writer = writer ?? throw new ArgumentNullException("Writer cannot be null!");
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            this.writer.Write($"Method {invocation.Request.Method.Name} of class {invocation.Request.Method.DeclaringType.Name} took {stopwatch.ElapsedMilliseconds} to execute!");
        }
    }
}
