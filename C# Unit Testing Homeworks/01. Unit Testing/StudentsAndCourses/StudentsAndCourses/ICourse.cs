using System.Collections.Generic;

namespace StudentsAndCourses
{
    public interface ICourse
    {
        string Name { get; }

        ICollection<IStudent> Students { get; }

        void AddStudent(IStudent studentToAdd);

        void RemoveStudent(IStudent studentToRemove);
    }
}