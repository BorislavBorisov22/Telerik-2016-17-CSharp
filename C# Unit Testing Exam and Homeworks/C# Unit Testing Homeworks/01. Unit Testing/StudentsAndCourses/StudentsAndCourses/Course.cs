namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course : ICourse
    {
        private const int MaxStudentsInCourse = 29;

        private string name;
        private ICollection<IStudent> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<IStudent>();
        }

        public ICollection<IStudent> Students
        {
            get
            {
                return new List<IStudent>(students);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringNullOfEmpty(value, "Courses name cannot be null or empty!");

                this.name = value;
            }
        }

        public void AddStudent(IStudent studentToAdd)
        {
            Validator.ObjectIsNull(studentToAdd, "Cannot add null student to course!");

            if (this.students.Contains(studentToAdd))
            {
                throw new InvalidOperationException("Cannot add a the same student more than once to a course!");
            }

            if (this.students.Count == MaxStudentsInCourse)
            {
                throw new InvalidOperationException($"Cannot add a student to a full course! Maximum number of students for a crouse is {MaxStudentsInCourse}.");
            }

            this.students.Add(studentToAdd);
        }

        public void RemoveStudent(IStudent studentToRemove)
        {
            Validator.ObjectIsNull(studentToRemove, "Cannot remove null student from course!");

            if (!this.students.Contains(studentToRemove))
            {
                throw new ArgumentException("No such student in this course that can be removed!");
            }

            this.students.Remove(studentToRemove);
        }
    }
}
