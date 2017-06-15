using Academy.Commands.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddStudentToSeasonCommand : ICommand
    {
        private readonly IAcademyData academyData;

        public AddStudentToSeasonCommand(IAcademyData academyData)
        {
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var studentUsername = parameters[0];
            var seasonId = parameters[1];

            var student = this.academyData.Students.Single(x => x.Username.ToLower() == studentUsername.ToLower());
            var season = this.academyData.Seasons[int.Parse(seasonId)];

            if (season.Students.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The Student {studentUsername} is already a part of Season {seasonId}!");
            }

            season.Students.Add(student);
            return $"Student {studentUsername} was added to Season {seasonId}.";
        }
    }
}
