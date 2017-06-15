using Academy.CLI.Container;
using Academy.Core.Contracts;
using Ninject;

namespace Academy.CLI
{
    public class StartUp
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new AcademyModule());
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
