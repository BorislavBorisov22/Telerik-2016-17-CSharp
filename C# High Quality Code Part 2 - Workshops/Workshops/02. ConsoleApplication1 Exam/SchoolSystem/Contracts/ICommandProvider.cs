namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines methods for providing commands
    /// </summary>
    public interface ICommandProvider
    {
        /// <summary>
        /// Provides a ICommand by given command name
        /// </summary>
        /// <param name="commandName">The name of the target command</param>
        /// <returns>The target Command</returns>
        ICommand GetCommand(string commandName);
    }
}