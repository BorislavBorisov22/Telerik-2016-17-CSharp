using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlowConditionalStatementsAndLoops
{
    public class Bowl
    {
        public Bowl()
        {
            this.Vegetables = new List<Vegetable>();
        }

        public IList<Vegetable> Vegetables { get; private set; }

        public void Add(Vegetable vegetableToAdd)
        {
            if (vegetableToAdd == null)
            {
                throw new ArgumentNullException("Cannot add a null vegetable to bowl!");
            }

            this.Vegetables.Add(vegetableToAdd);
        }
    }
}
