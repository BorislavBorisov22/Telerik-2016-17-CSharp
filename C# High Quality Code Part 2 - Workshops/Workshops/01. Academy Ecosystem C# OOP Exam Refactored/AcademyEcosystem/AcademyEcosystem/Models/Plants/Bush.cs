using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Bush : Plant
    {
        public Bush(IPoint location)
            : base(location, 4)
        {
        }
    }
}
