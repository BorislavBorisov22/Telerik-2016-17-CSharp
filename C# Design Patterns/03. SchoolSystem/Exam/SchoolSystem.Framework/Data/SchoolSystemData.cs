using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;
using System;

namespace SchoolSystem.Framework.Data
{
    public class SchoolSystemData : ISchoolSystemData
    {
        private readonly IDictionary<int, ITeacher> teachers;
        private readonly IDictionary<int, IStudent> students;

        public SchoolSystemData()
        {
            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public void AddStudent(int id, IStudent student)
        {
            this.students.Add(id, student);
        }

        public void AddTeacher(int id, ITeacher teacher)
        {
            this.teachers.Add(id, teacher);
        }

        public IStudent GetStudent(int id)
        {
            return this.students[id];
        }

        public ITeacher GetTeacher(int id)
        {
            return this.teachers[id];
        }

        public void RemoveStudent(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.students.Remove(id);
        }

        public void RemoveTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.teachers.Remove(id);
        }
    }
}
