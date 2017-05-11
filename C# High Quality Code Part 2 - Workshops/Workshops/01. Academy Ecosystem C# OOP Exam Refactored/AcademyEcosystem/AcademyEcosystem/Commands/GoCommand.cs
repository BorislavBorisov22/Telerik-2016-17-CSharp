using System;
using System.Collections.Generic;
using AcademyEcosystem.Commands.Contracts;
using System.Linq;
using System.Text;

namespace AcademyEcosystem.Commands
{
    internal class GoCommand : LocationRelatedCommand, ICommand
    {
        public string Execute(IList<string> commandWords)
        {
            string name = commandWords[0];
            IPoint destination = this.LocationParser.ParsePoint(commandWords[1]);

            IAnimal targetAnimal = Engine.Animals.FirstOrDefault(x => x.Name == name);

            if (targetAnimal == null)
            {
                throw new ArgumentNullException($"Animal with name {name} was not found!");
            }

            int travelTime = Point.GetManhattanDistance(targetAnimal.Location, destination);

            // update all organisms
            foreach (var organism in Engine.AllOgranisms)
            {
                organism.Update(travelTime);
            }

            targetAnimal.GoTo(destination);

            StringBuilder message = new StringBuilder();

            string encountersMessage = this.HandleEncounters(targetAnimal);
            string deadReports = this.RemoveAndReportDead();

            message.AppendLine(encountersMessage);
            message.AppendLine(deadReports);

            return message.ToString().Trim();   
        }

        private string HandleEncounters(IAnimal current)
        {
            var encountersMessage = new StringBuilder();

            IList<IOrganism> allEncountered = new List<IOrganism>();
            foreach (var organism in Engine.AllOgranisms)
            {
                if (organism.Location.X == current.Location.X && organism.Location.Y == current.Location.Y && !(organism == current))
                {
                    allEncountered.Add(organism);
                }
            }

            var currentAsHerbivore = current as IHerbivore;
            if (currentAsHerbivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsHerbivore.EatPlant(encountered as Plant);
                    if (eatenQuantity != 0)
                    {
                        encountersMessage.AppendLine(string.Format("{0} ate {1} from {2}", current, eatenQuantity, encountered));
                    }
                }
            }

            allEncountered.RemoveAll(o => !o.IsAlive);

            var currentAsCarnivore = current as ICarnivore;
            if (currentAsCarnivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsCarnivore.TryEatAnimal(encountered as Animal);
                    if (eatenQuantity != 0)
                    {
                        encountersMessage.AppendLine(string.Format("{0} ate {1} from {2}", current, eatenQuantity, encountered));
                    }
                }
            }

            return encountersMessage.ToString();
        }

        private string RemoveAndReportDead()
        {
            var reportsBuilder = new StringBuilder();

            foreach (var organism in Engine.AllOgranisms)
            {
                if (!organism.IsAlive)
                {
                    reportsBuilder.AppendLine(string.Format("{0} is dead ;(", organism));
                }
            }

            Engine.AllOgranisms.RemoveAll(o => !o.IsAlive);
            Engine.Plants.RemoveAll(o => !o.IsAlive);
            Engine.Animals.RemoveAll(o => !o.IsAlive);

            return reportsBuilder.ToString().Trim();
        }
    }
}
