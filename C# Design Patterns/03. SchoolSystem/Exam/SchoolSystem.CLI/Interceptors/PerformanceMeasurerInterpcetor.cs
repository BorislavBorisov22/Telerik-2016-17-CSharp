using System;
using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;
using System.Diagnostics;

namespace SchoolSystem.Cli.Interceptors
{
    public class PerformanceMeasurerInterpcetor : IInterceptor
    {
        private readonly IWriter writer;
        private readonly Stopwatch stopWatch;

        public PerformanceMeasurerInterpcetor(IWriter writer, Stopwatch stopWatch)
        {
            this.writer = writer ?? throw new ArgumentNullException("Writer cannot be null!");
            this.stopWatch = stopWatch ?? throw new ArgumentNullException("Stopwatch cannot be null!");
        }

        public void Intercept(IInvocation invocation)
        {
            writer.WriteLine($"Calling method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name}...");

            this.stopWatch.Start();
            invocation.Proceed();
            this.stopWatch.Stop();

            writer.WriteLine($"Total execution time for method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name} is {this.stopWatch.ElapsedMilliseconds} milliseconds.");
        }
    }
}
