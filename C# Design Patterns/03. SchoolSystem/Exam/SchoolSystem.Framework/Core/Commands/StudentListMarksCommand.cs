using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly ISchoolSystemData schoolSystemData;

        public StudentListMarksCommand(ISchoolSystemData schoolSystemData)
        {
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.schoolSystemData.GetStudent(studentId);
            return student.ListMarks();
        }
    }
}
