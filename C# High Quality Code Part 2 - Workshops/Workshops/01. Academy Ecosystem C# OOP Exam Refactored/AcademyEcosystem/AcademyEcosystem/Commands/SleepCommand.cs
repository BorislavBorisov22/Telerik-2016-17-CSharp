using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;
using System.Linq;
using System;

namespace AcademyEcosystem.Commands
{
    internal class SleepCommand : ICommand
    {
        public string Execute(IList<string> commandWords)
        {
            string name = commandWords[0];
            int sleepTime = int.Parse(commandWords[1]);

            IAnimal targetAnimal = Engine.Animals.FirstOrDefault(x => x.Name == name);

            if (targetAnimal == null)
            {
                throw new ArgumentNullException($"Animal with name {name} was not found!");
            }

            targetAnimal.Sleep(sleepTime);
            string message = $"{name} has been put to sleep for {sleepTime}";
            return message;
        }
    }
}
