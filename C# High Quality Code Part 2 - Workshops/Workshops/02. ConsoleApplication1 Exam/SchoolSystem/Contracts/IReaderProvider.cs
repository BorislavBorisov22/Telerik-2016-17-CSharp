namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represenst a source readers provider
    /// </summary>
    public interface IReaderProvider
    {
        /// <summary>
        /// returns a read source as a string
        /// </summary>
        /// <returns></returns>
        string ReadLine();
    }
}
