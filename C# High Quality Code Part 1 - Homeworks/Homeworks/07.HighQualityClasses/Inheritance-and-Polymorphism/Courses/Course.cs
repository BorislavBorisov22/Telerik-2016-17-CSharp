﻿namespace InheritanceAndPolymorphism.Courses
{
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string TeacherName { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateNullOrEmptyString(value, "Course Name cannot be null or empty!");

                this.name = value;
            }
        }

        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
