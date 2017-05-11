using AcademyEcosystem.Commands.Contracts;
using System.Collections.Generic;

namespace AcademyEcosystem.Core.Contracts
{
    public interface ICommandProvider
    {
        ICommand GetCommand(IList<string> commandName);
    }
}
