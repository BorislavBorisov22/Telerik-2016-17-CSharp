namespace Dealership.Contracts
{
    using Engine;
    using System.Collections.Generic;

    public interface ICommandParser
    {
        IList<ICommand> ReadCommands();
    }
}
