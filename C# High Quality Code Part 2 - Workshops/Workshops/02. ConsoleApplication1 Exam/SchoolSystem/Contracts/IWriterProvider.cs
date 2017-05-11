namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represenets a source wirter
    /// </summary>
    public interface IWriterProvider
    {
        /// <summary>
        /// Writes string in some kind of source
        /// </summary>
        /// <param name="message">the message to be written</param>
        void WriteLine(string message);
    }
}
