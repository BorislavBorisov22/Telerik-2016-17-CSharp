using SchoolSystem.Enum;
using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Respresents the students in the school system
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; }

        IList<IMark> Marks { get; }

        /// <summary>
        /// Provides information for the students grades as a string
        /// </summary>
        /// <returns></returns>
        string ListMarks();
    }
}