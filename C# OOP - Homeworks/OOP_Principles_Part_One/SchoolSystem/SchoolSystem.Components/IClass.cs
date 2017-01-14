using System.Collections.Generic;

namespace SchoolSystem.Components
{
    public interface IClass
    {
        List<IStudent> Students { get; }
        List<ITeacher> Teachers { get; }

        void AddStudent(IStudent student);
        void AddTeacher(ITeacher teacher);
        string ToString();
    }
}