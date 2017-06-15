using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    { 
        private readonly ISchoolSystemData schoolSystemData;

        public TeacherAddMarkCommand(ISchoolSystemData schoolSystemData)
        {
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.schoolSystemData.GetStudent(studentId);
            var teacher = this.schoolSystemData.GetTeacher(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
