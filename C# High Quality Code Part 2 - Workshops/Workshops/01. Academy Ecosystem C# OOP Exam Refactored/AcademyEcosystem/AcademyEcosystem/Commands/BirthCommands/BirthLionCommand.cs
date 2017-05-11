using AcademyEcosystem.Commands.Contracts;
using System.Collections.Generic;

namespace AcademyEcosystem.Commands
{
    internal class BirthLionCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string name = parameters[1];
            IPoint position = this.LocationParser.ParsePoint(parameters[2]);

            var lion = new Lion(name, position);
            Engine.AllOgranisms.Add(lion);
            Engine.Animals.Add(lion);

            string message = $"Lion {name} was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
