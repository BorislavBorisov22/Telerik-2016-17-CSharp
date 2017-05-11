using SchoolSystem.Contracts;
using SchoolSystem.Core;
using SchoolSystem.Enums;
using SchoolSystem.Models;

using System.Collections.Generic;

namespace SchoolSystem.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Teachers.Add(id, new Teacher(parameters[0], parameters[1], int.Parse(parameters[2])));
            return $"A new teacher with name {parameters[0]} {parameters[1]}, subject {(Subject)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
