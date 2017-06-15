using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface IDealershipFactory
    {
        IUser GetUser(string username, string firstName, string lastName, string password, string role);

        IComment GetComment(string content);

        IVehicle GetCar(string make, string model, decimal price, int seats);

        IVehicle GetMotorcycle(string make, string model, decimal price, string category);

        IVehicle GetTruck(string make, string model, decimal price, int weightCapacity);
    }
}
