using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyData academyData;

        public CreateSeasonCommand(IAcademyFactory factory, IAcademyData academyData)
        {
            this.factory = factory ?? throw new ArgumentNullException("AcademyFactory cannot be null!");
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var startingYear = parameters[0];
            var endingYear = parameters[1];
            var initiative = parameters[2];

            var season = this.factory.CreateSeason(startingYear, endingYear, initiative);
            this.academyData.Seasons.Add(season);

            return $"Season with ID {this.academyData.Seasons.Count - 1} was created.";
        }
    }
}
