using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly ISchoolSystemData schoolSystemData;

        public RemoveStudentCommand(ISchoolSystemData schoolSystemData)
        {
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.schoolSystemData.RemoveStudent(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
