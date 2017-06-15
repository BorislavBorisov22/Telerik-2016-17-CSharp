using Ninject;
using SchoolSystem.Framework.Core;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            var schoolSystemModule = new SchoolSystemModule();
            var kernel = new StandardKernel(schoolSystemModule);

            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}