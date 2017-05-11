using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Interface implemented by any class that processes the SchoolSystem
    /// input commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Provides execution of a an input command for the SchoolSystem 
        /// </summary>
        /// <param name="parameters">The command to process parameters</param>
        /// <returns>The result of the command execution with the given parameters</returns>
        string Execute(IList<string> parameters);
    }
}
