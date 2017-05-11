using System.Collections.Generic;

namespace AcademyEcosystem.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
