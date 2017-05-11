using AcademyEcosystem.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Commands
{
    internal class BirthWolfCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string name = parameters[1];
            IPoint position = this.LocationParser.ParsePoint(parameters[2]);

            var wolf = new Wolf(name, position);
            Engine.AllOgranisms.Add(wolf);
            Engine.Animals.Add(wolf);

            string message = $"Wolf {name} was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
