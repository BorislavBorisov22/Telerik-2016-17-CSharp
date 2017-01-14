namespace SchoolSystem.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person, ICommentable, INamable, ITeacher
    {
        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public Teacher(string name, string comment)
            : base(name, comment)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }

            private set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            if (this.AlreadyHasDiscipline(discipline) && this.Disciplines.Count > 0)
            {
                throw new ArgumentException("Teacher cannot have two disciplines of the same type");
            }

            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.Append("Disciplines: ");
            for (int i = 0; i < this.Disciplines.Count; i++)
            {
                if (i != this.Disciplines.Count - 1)
                {
                    output.Append(string.Format("{0} ({1} lectures(s) and {1} exercise(s)), ", this.Disciplines[i].Name, this.Disciplines[i].NumberOfLectures,this.Disciplines[i].NumberOfExercises));
                }
                else
                {
                    output.Append(string.Format("{0} ({1} lectures(s) and {1} exercise(s))", this.Disciplines[i].Name, this.Disciplines[i].NumberOfLectures, this.Disciplines[i].NumberOfExercises));
                }
            }

            return output.ToString().Trim();
        }

        private bool AlreadyHasDiscipline(Discipline discipline)
        {
            foreach (var disp in this.Disciplines)
            {
                if (disp.Name == discipline.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
