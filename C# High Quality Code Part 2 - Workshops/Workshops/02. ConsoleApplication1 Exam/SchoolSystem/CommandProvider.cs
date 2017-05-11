using SchoolSystem.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SchoolSystem
{
    public class CommandProvider : ICommandProvider
    {
        public ICommand GetCommand(string commandName)
        {           
            var assembly = GetType().GetTypeInfo().Assembly;

            var typeInfo = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .FirstOrDefault();

            if (typeInfo == null)
            {
                // throw exception when typeinfo is null
                throw new ArgumentException("The passed command is not found!");
            }

            var command = Activator.CreateInstance(typeInfo) as ICommand;

            return command;
        }
    }
}
