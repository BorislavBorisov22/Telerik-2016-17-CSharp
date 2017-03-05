namespace StudentsAndCourses
{
    public interface IStudent
    {
        string Name { get; }

        int UniqueNumber { get; }

        void JoinCourse(ICourse courseToJoin);

        void LeaveCourse(ICourse courseToLeave);
    }
}