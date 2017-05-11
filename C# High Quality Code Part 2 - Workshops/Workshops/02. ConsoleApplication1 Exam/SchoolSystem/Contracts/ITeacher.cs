using SchoolSystem.Enums;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents the teachers in the school system
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; }

        /// <summary>
        /// Add mark with a given value to a given student
        /// </summary>
        /// <param name="student">Student to recieve the mark</param>
        /// <param name="val">Mark value</param>
        void AddMark(IStudent student, float val);
    }
}