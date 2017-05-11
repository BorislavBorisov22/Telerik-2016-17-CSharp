using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;

namespace AcademyEcosystem.Commands
{
    internal class BirthDeerCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string name = parameters[1];
            IPoint position = this.LocationParser.ParsePoint(parameters[2]);

            var deer = new Deer(name, position);
            Engine.AllOgranisms.Add(deer);
            Engine.Animals.Add(deer);

            string message = $"Deer {name} was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
