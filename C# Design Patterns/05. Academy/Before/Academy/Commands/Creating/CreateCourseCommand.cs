using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateCourseCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyData academyData;

        public CreateCourseCommand(IAcademyFactory factory, IAcademyData academyData)
        {
            this.factory = factory ?? throw new ArgumentNullException("AcademyFactory cannot be null!");
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var name = parameters[1];
            var lecturesPerWeek = parameters[2];
            var startingDate = parameters[3];

            var season = this.academyData.Seasons[int.Parse(seasonId)];
            var course = this.factory.CreateCourse(name, lecturesPerWeek, startingDate);
            season.Courses.Add(course);

            return $"Course with ID {season.Courses.Count - 1} was created in Season {seasonId}.";
        }
    }
}
