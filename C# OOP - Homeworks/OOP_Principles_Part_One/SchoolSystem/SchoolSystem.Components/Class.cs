namespace SchoolSystem.Components
{
    using System.Collections.Generic;
    using System.Text;

    public class Class : NamableEntity, INamable, IClass
    {
        private List<IStudent> students;
        private List<ITeacher> teachers;

        public Class(string name)
            : base(name)
        {
            this.students = new List<IStudent>();
            this.teachers = new List<ITeacher>();
        }

        public List<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }
        }

        public List<ITeacher> Teachers
        {
            get
            {
                return new List<ITeacher>(this.teachers);
            }
        }

        public void AddStudent(IStudent student)
        {
            this.students.Add(student);
        }

        public void AddTeacher(ITeacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Class name: {0}", this.Name))
                .AppendLine("Teachers in class:");

            foreach (var teacher in this.Teachers)
            {
                output.AppendLine(teacher.ToString());
            }

            output.AppendLine("Students in class");
            foreach (var student in this.Students)
            {
                output.AppendLine(student.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
