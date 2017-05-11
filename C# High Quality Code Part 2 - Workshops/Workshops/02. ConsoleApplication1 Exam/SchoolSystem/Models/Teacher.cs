using SchoolSystem.Contracts;
using SchoolSystem.Enums;
using System;

namespace SchoolSystem.Models
{
    public class Teacher : Person, ITeacher
    {
        private Subject subject;

        public Teacher(string firstName, string lastName, int subject)
            : base(firstName, lastName)
        { 
            if (System.Enum.IsDefined(typeof(Subject), subject))
            {
                this.subject = (Subject)subject;
            }
            else
            {
                throw new ArgumentException("Subject must be a valid Subject type!");
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }
        }

        public void AddMark(IStudent student, float val)            
        {
            IMark mark = new Mark(this.Subject, val);
            student.Marks.Add(mark);
        }      
    }
}
