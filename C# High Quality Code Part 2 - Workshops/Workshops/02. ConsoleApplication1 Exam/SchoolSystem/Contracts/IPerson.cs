namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents students and teachers in the school system and any unit with
    /// first and last name
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }
    }
}