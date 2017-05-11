using System;
using AcademyEcosystem.Commands.Contracts;
using AcademyEcosystem.Core.Contracts;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace AcademyEcosystem.Core
{ 
    public class CommandProvider : ICommandProvider
    {
        private const string BirthCommandName = "birth";

        public ICommand GetCommand(IList<string> commandParams)
        {
            string commandName = commandParams[0];

            var assembly = GetType().GetTypeInfo().Assembly;

            var typeInfo = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => 
                {
                    bool isMatch = type.Name.ToLower().Contains(commandName.ToLower());
                    if (commandName == BirthCommandName)
                    {
                        isMatch = isMatch && type.Name.ToLower().Contains(commandParams[1].ToLower());
                    }

                    return isMatch;
                    })
                .FirstOrDefault();

            if (typeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }
            
            var command = Activator.CreateInstance(typeInfo) as ICommand;

            return command;
        }
    }
}
