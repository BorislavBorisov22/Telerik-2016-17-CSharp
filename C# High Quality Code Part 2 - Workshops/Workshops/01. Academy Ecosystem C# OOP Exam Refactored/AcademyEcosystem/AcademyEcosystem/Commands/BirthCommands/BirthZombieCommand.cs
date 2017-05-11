using System;
using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;

namespace AcademyEcosystem.Commands
{
    internal class BirthZombieCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string name = parameters[1];
            IPoint position = this.LocationParser.ParsePoint(parameters[2]);

            var zombie = new Zombie(name, position);
            Engine.AllOgranisms.Add(zombie);
            Engine.Animals.Add(zombie);

            string message = $"Zombie {name} was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
