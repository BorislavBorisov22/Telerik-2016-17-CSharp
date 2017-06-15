using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Framework.Commands.Creating
{
    public class CreateLectureResourceCommand : ICommand
    {
        private readonly IAcademyFactory academyFactory;
        private readonly IAcademyData academyData;

        public CreateLectureResourceCommand(IAcademyFactory academyFactory, IAcademyData academyData)
        {
            this.academyFactory = academyFactory ?? throw new ArgumentNullException("AcademyFactory cannot be null");
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            int seasonId = int.Parse(parameters[0]);
            int courseId = int.Parse(parameters[1]);
            int lectureId = int.Parse(parameters[2]);

            string resourceType = parameters[3];
            string resourceTitle = parameters[4];
            string resourceUrl = parameters[5];

            var season = this.academyData.Seasons[seasonId];
            var course = season.Courses[courseId];
            var lecture = course.Lectures[lectureId];

            if (lecture.Resources.Any() && lecture.Resources.Any(x => x.Name == resourceTitle))
            {
                throw new ArgumentException($"There is already a resource with this title in {course.Name}.");
            }

            var resource = this.academyFactory.CreateLectureResource(resourceType, resourceTitle, resourceUrl);
            lecture.Resources.Add(resource);

            return $"Lecture resource with ID {lecture.Resources.Count - 1} was created in Lecture {seasonId}.{course.Name}.{lecture.Name}.";
        }
    }
}
