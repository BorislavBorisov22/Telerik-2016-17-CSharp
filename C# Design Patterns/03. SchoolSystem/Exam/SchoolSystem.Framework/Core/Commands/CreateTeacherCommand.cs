using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Factories.Contracts;
using System;
using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly ITeacherFactory teacherFactory;
        private readonly ISchoolSystemData schoolSystemData;
        private readonly IMarkFactory markFactory;
        private int currentTeacherId;

        public CreateTeacherCommand(ITeacherFactory teacherFactory, ISchoolSystemData schoolSystemData, IMarkFactory markFactory)
        {
            this.teacherFactory = teacherFactory ?? throw new ArgumentNullException("Teacher Factory cannot be null!");
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
            this.markFactory = markFactory ?? throw new ArgumentNullException("Mark factory cannot be null!");
            this.currentTeacherId = 0;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject);
            this.schoolSystemData.AddTeacher(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId++} was created.";
        }
    }
}
