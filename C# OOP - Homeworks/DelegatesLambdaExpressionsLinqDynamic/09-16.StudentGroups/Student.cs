namespace StudentGroups
{
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public Student(
            string firstName,
            string lastName,
            string facultyNumber,
            string tel,
            string email,List<int> marks,
            int groupNumber,
            Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.Group = group;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FacultyNumber { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }
       
        public int GroupNumber { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("First Name: {0}", this.FirstName))
                .AppendLine(string.Format("Last Name: {0}", this.LastName))
                .AppendLine(string.Format("Faculty Number: {0}", this.FacultyNumber))
                .AppendLine(string.Format("Tel: {0}", this.Tel))
                .AppendLine(string.Format("Email: {0}", this.Email))
                .AppendLine(string.Format("Marks: {0}", string.Join(", ", this.Marks)))
                .AppendLine(string.Format("Group Number: {0}", this.GroupNumber));

            return output.ToString().Trim();
        }
    }
}
