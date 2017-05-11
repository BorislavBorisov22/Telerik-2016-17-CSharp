using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Tree : Plant
    {
        public Tree(IPoint location)
            : base(location, 15)
        {
        }
    }
}
