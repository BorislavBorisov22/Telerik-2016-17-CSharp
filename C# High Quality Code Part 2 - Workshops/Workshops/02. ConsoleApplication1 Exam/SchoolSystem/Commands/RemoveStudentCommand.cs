using SchoolSystem.Contracts;
using SchoolSystem.Core;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.Students.Remove(int.Parse(paras[0]));
            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}
