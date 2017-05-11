using System;
using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;

namespace AcademyEcosystem.Commands
{
    internal class BirthBushCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            IPoint position = this.LocationParser.ParsePoint(parameters[1]);

            var bush = new Bush(position);
            Engine.AllOgranisms.Add(bush);
            Engine.Plants.Add(bush);

            string message = $"Bush was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
