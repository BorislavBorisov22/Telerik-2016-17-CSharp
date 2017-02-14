namespace StudentsAndCourses
{
    public class Student : IStudent
    {
        private const int MinUniqueNumber = 10000;
        private const int MaxUniqueNumber = 99999;

        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringNullOfEmpty(value, "Student's name cannot be null or empty!");

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                Validator.ValidateIntRange(value, MinUniqueNumber, MaxUniqueNumber, $"Student's unique numbers shoub be between {MinUniqueNumber} and {MaxUniqueNumber}");

                this.uniqueNumber = value;
            }
        }

        public void JoinCourse(ICourse courseToJoin)
        {
            Validator.ObjectIsNull(courseToJoin, "Student cannot join an empty course!");

            courseToJoin.AddStudent(this);
        }

        public void LeaveCourse(ICourse courseToLeave)
        {
            Validator.ObjectIsNull(courseToLeave, "Student cannot leave an empty course!");

            courseToLeave.RemoveStudent(this);
        }
    }
}
