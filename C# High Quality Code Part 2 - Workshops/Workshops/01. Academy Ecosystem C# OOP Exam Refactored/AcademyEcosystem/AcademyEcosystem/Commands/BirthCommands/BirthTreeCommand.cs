using AcademyEcosystem.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace AcademyEcosystem.Commands
{
    internal class BirthTreeCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            IPoint position = this.LocationParser.ParsePoint(parameters[1]);

            var tree = new Tree(position);
            Engine.AllOgranisms.Add(tree);
            Engine.Plants.Add(tree);

            string message = $"Tree created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
