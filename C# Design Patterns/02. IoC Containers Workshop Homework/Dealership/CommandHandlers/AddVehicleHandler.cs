using System;
using Dealership.Engine;
using Dealership.Contracts;
using Dealership.Common.Enums;
using Dealership.Factories;
using Dealership.Engine.Providers;
using Bytes2you.Validation;

namespace Dealership.CommandHandlers
{
    public class AddVehicleHandler : CommandHandler
    {
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private readonly IUserProvider userProvider;
        private readonly IDealershipFactory factory;

        public AddVehicleHandler(IUserProvider userProvider, IDealershipFactory factory)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.userProvider = userProvider;
            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddVehicle";
        }

        protected override string Process(ICommand command)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            return this.AddVehicle(typeEnum, make, model, price, additionalParam);

        }

        private string AddVehicle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            IVehicle vehicle = null;

            if (type == VehicleType.Car)
            {
                vehicle = this.factory.GetCar(make, model, price, int.Parse(additionalParam));
            }
            else if (type == VehicleType.Motorcycle)
            {
                vehicle = this.factory.GetMotorcycle(make, model, price, additionalParam);
            }
            else if (type == VehicleType.Truck)
            {
                vehicle = this.factory.GetTruck(make, model, price, int.Parse(additionalParam));
            }

            this.userProvider.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, this.userProvider.LoggedUser.Username);
        }
    }
}
