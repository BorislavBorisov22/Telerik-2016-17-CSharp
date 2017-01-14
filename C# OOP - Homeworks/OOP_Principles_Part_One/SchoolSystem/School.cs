namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Text;
    using SchoolSystem.Components;

    public class School : NamableEntity, INamable
    {
        private IList<IClass> classes;

        public School(string name)
            : base(name)
        {
            this.classes = new List<IClass>();
        }

        public List<IClass> Classes
        {
            get
            {
                return new List<IClass>(this.classes);
            }

            private set
            {
                this.classes = value;
            }
        }

        public void AddClass(IClass classToAdd)
        {
            this.classes.Add(classToAdd);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("School Name: {0}", this.Name))
                .AppendLine($"Classes in this school ({this.Classes.Count} in total) :");

            foreach (var schoolClass in this.Classes)
            {
                output.AppendLine("-----------------------------------");
                output.AppendLine(schoolClass.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
