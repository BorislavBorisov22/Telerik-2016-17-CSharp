using System.Collections.Generic;

namespace SchoolSystem.Components
{
    public interface ITeacher
    {
        List<Discipline> Disciplines { get; }

        void AddDiscipline(Discipline discipline);

        string ToString();
    }
}