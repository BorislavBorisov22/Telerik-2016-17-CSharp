using AcademyEcosystem.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Commands
{
    internal class BirthGrassCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            IPoint position = this.LocationParser.ParsePoint(parameters[1]);

            var grass = new Grass(position);
            Engine.AllOgranisms.Add(grass);
            Engine.Plants.Add(grass);

            string message = $"Grass created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
