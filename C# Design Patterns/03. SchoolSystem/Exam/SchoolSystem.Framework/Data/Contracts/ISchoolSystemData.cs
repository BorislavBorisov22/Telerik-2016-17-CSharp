using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Data.Contracts
{
    public interface ISchoolSystemData
    {
        void AddStudent(int id, IStudent student);

        void AddTeacher(int id, ITeacher teacher);

        void RemoveStudent(int id);

        void RemoveTeacher(int id);

        IStudent GetStudent(int id);

        ITeacher GetTeacher(int id);
    }
}
