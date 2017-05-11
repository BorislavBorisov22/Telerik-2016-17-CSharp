using SchoolSystem.Contracts;
using SchoolSystem.Core;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teacherId = int.Parse(prms[0]);
            var studentId = int.Parse(prms[1]);

            var student = Engine.Students[studentId];
            var teacher = Engine.Teachers[teacherId];

            teacher.AddMark(student, float.Parse(prms[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
