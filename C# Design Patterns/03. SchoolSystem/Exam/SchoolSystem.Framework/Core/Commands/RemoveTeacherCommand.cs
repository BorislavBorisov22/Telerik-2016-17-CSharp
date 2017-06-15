using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly ISchoolSystemData schoolSystemData;

        public RemoveTeacherCommand(ISchoolSystemData schoolSystemData)
        {
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            this.schoolSystemData.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
