using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;

namespace Dealership.Tests.Models.Fakes
{
    public class FakeVehicle : Vehicle
    {
        public FakeVehicle(string make, string model, decimal price, VehicleType type) 
            : base(make, model, price, type)
        {
        }

        protected override string PrintAdditionalInfo()
        {
            throw new NotImplementedException();
        }
    }
}
