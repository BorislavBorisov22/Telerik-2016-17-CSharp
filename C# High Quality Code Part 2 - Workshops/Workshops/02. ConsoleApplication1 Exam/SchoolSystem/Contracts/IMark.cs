using SchoolSystem.Enums;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents the marks students get from teachers
    /// </summary>
    public interface IMark
    {
        Subject Subject { get; }

        float Value { get; }
    }
}