namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private string name;
        private ICollection<IStudent> students;
        private ICollection<ICourse> courses;

        public School(string name)
        {
            this.Name = name;
            this.students = new List<IStudent>();
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringNullOfEmpty(value, "School's name cannot be null or empty!");

                this.name = value;
            }
        }

        public ICollection<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }           
        }

        public ICollection<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
        }

        public void AddStudent(IStudent studentToAdd)
        {
            Validator.ObjectIsNull(studentToAdd, "Cannot add null student in school!");

            if (this.students.Any(s => s.UniqueNumber == studentToAdd.UniqueNumber))
            {
                throw new InvalidOperationException("Student with such unique number already exists");
            }

            this.students.Add(studentToAdd);
        }

        public void RemoveStudent(IStudent studentToRemove)
        {
            Validator.ObjectIsNull(studentToRemove, "Cannot remove null student from school!");

            if (!this.students.Any(s => s == studentToRemove))
            {
                throw new ArgumentException("No such student in this school that can be removed!");
            }

            this.students.Remove(studentToRemove);
        }

        public void AddCourse(ICourse courseToAdd)
        {
            Validator.ObjectIsNull(courseToAdd, "Cannot add null course to school!");
            
            if (this.courses.Any(c => c.Name == courseToAdd.Name))
            {
                throw new InvalidOperationException("Cannot a more than one courses with the same name!");
            }

            this.courses.Add(courseToAdd);    
        }


        public void RemoveCourse(ICourse courseToRemove)
        {
            Validator.ObjectIsNull(courseToRemove, "Cannot remove null course from school!");

            if (!this.courses.Contains(courseToRemove))
            {
                throw new InvalidOperationException("Cannot remove a non existing course!");
            }

            this.courses.Remove(courseToRemove);
        }
    }
}
