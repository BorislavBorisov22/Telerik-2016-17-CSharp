using Dealership.Engine;
using Dealership.Factories.Contracts;

namespace Dealership.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string input)
        {
            return new Command(input);
        }
    }
}
