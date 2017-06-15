﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddTrainerToSeasonCommand : ICommand
    {
        private readonly IAcademyData academyData;

        public AddTrainerToSeasonCommand(IAcademyData academyData)
        {
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var trainerUsername = parameters[0];
            var seasonId = parameters[1];

            var trainer = this.academyData.Trainers.Single(x => x.Username.ToLower() == trainerUsername.ToLower());
            var season = this.academyData.Seasons[int.Parse(seasonId)];

            if (season.Trainers.Any(x => x.Username.ToLower() == trainerUsername.ToLower()))
            {
                throw new ArgumentException($"The Trainer {trainerUsername} is already a part of Season {seasonId}!");
            }

            season.Trainers.Add(trainer);
            return $"Trainer {trainerUsername} was assigned to Season {seasonId}.";
        }
    }
}
