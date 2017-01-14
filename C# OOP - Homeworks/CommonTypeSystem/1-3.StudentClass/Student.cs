namespace Students
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName, 
            string middleName,
            string lastName,
            string ssn,
            string address,
            string mobilePhone, 
            string email,
            int course,
            Specialty specialty,
            University univerisity,
            Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.StudentSecurityNumber = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.Univeristy = univerisity;
            this.Faculty = faculty;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string StudentSecurityNumber { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int Course { get; set; }

        public Specialty Specialty { get; set; }

        public University Univeristy { get; set; }

        public Faculty Faculty { get; set; }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.CompareTo(secondStudent) == 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.CompareTo(secondStudent) == 0)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            var objAsStudent = obj as Student;
            return this.StudentSecurityNumber == objAsStudent.StudentSecurityNumber;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.StudentSecurityNumber.GetHashCode();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName))
                .AppendLine(string.Format("Security number: {0}, Address: {1}, Phone: {2}", this.StudentSecurityNumber, this.Address, this.MobilePhone))
                .AppendLine(string.Format("Email: {0}, Course: {1}", this.Email, this.Course))
                .AppendLine(string.Format("Specialty: {0}, University: {1}, Faculty: {2}", this.Specialty, this.Univeristy, this.Faculty));

            return output.ToString().Trim();
        }

        public object Clone()
        {
            return new Student(
                this.FirstName,
                this.MiddleName, 
                this.LastName,
                this.StudentSecurityNumber,
                this.Address,
                this.MobilePhone,
                this.Email,
                this.Course,
                this.Specialty,
                this.Univeristy,
                this.Faculty);
        }

        public int CompareTo(Student other)
        {
            int firstNameComparison = this.FirstName.CompareTo(other.FirstName);
            
            if (firstNameComparison != 0)
            {
                return firstNameComparison;
            }

            int middleNameComparison = this.MiddleName.CompareTo(other.MiddleName);

            if (middleNameComparison != 0)
            {
                return middleNameComparison;
            }

            int lastNameComparison = this.LastName.CompareTo(other.LastName);

            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }

            int ssdComparison = this.StudentSecurityNumber.CompareTo(other.StudentSecurityNumber);

            if (ssdComparison != 0)
            {
                return ssdComparison;
            }

            return 0;
        }
    }
}
