using System;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        private readonly IMarkFactory markFactory;

        public Teacher(string firstName, string lastName, Subject subject, IMarkFactory markFactory)
            : base(firstName, lastName)
        {
            this.markFactory = markFactory ?? throw new ArgumentNullException("Mark factory cannot be null!");
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.markFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}
