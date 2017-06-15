using Ninject;
using ProjectManager.Common.Contracts;
using ProjectManager.Container;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new ProjectManagerModule());
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
