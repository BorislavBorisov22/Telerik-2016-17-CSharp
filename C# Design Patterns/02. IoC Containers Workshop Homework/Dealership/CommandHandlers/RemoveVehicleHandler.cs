using Bytes2you.Validation;
using Dealership.Common;
using Dealership.Engine;
using Dealership.Engine.Providers;

namespace Dealership.CommandHandlers
{
    public class RemoveVehicleHandler : CommandHandler
    {
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        private readonly IUserProvider userProvider;

        public RemoveVehicleHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();
          
            this.userProvider = userProvider;      
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveVehicle";
        }

        protected override string Process(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            return this.RemoveVehicle(vehicleIndex);
        }

        private string RemoveVehicle(int vehicleIndex)
        {
            Validator.ValidateIntRange(vehicleIndex, 0, this.userProvider.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = this.userProvider.LoggedUser.Vehicles[vehicleIndex];

            this.userProvider.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, this.userProvider.LoggedUser.Username);
        }
    }
}
