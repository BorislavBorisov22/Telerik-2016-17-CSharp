using SchoolSystem.Contracts;
using SchoolSystem.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {
        private const int MinGradeValue = 1;
        private const int MaxGradeValue = 12;

        private readonly IList<IMark> marks;
        private Grade grade;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
            this.marks = new List<IMark>();
        }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.Validator.ValidateValueRange(MinGradeValue, MaxGradeValue, (int)value, $"Grade must be between {MinGradeValue} and {MaxGradeValue}");
            }
        }

        public string ListMarks()
        {
            // bug found -> returned empty string when student had no marks
            if (this.marks.Count == 0)
            {
                return "This student has no marks.";
            }

            var result = new StringBuilder();
            result.AppendLine("The student has these marks:");

            var marksAsString = this.marks.Select(m => $"{m.Subject} => {m.Value}").ToList();
            result.AppendLine(string.Join("\n", marksAsString));

            return result.ToString().Trim();
        }
    }
}
