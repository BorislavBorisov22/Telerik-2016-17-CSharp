using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using System;
using SchoolSystem.Framework.Data.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IStudentFactory studentFactory;
        private readonly ISchoolSystemData schoolSystemData;
        private int currentStudentId;

        public CreateStudentCommand(IStudentFactory studentFactory, ISchoolSystemData schoolSystemData)
        {
            this.schoolSystemData = schoolSystemData ?? throw new ArgumentNullException("School system data cannot be null!");
            this.studentFactory = studentFactory ?? throw new ArgumentNullException("Student factory cannot be null!");
            this.currentStudentId = 0;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);

            this.schoolSystemData.AddStudent(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {this.currentStudentId++} was created.";
        }
    }
}
