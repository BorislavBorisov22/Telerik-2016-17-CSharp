using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateTrainerCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyData academyData;

        public CreateTrainerCommand(IAcademyFactory factory, IAcademyData academyData)
        {
            this.factory = factory ?? throw new ArgumentNullException("AcademyFactory cannot be null!");
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var technologies = parameters[1];

            if (this.academyData.Students.Any(x => x.Username.ToLower() == username.ToLower()) ||
                this.academyData.Trainers.Any(x => x.Username.ToLower() == username.ToLower()))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var trainer = this.factory.CreateTrainer(username, technologies);
            this.academyData.Trainers.Add(trainer);

            return $"Trainer with ID {this.academyData.Trainers.Count - 1} was created.";
        }
    }
}
