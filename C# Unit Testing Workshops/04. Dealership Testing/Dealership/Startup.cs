using Dealership.Engine;
using System;
using System.IO;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var engine = new DealershipEngine();
            engine.Start();
        }
    }
}
