using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;

namespace AcademyEcosystem.Commands
{
    internal class BirthBoarCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string name = parameters[1];
            IPoint position = this.LocationParser.ParsePoint(parameters[2]);

            var boar = new Boar(name, position);
            Engine.AllOgranisms.Add(boar);
            Engine.Animals.Add(boar);

            string message = $"Boar {name} was created at ({position.X}, {position.Y})";
            return message;
        }
    }
}
