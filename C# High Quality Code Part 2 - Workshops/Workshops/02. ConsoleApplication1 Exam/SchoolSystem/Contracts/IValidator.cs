using System;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represenets a validatori for the information provided for differents components if the school system
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Throws ArgumentNullExcaption if given value is null or empty
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="message">Message for the eventual exception</param>
        void ValidateNullOrEmptyString(string value, string message);

        /// <summary>
        /// Throw ArgumentOutOfRangeException if given value is out of the given range
        /// </summary>
        /// <typeparam name="T">Any IComparable type</typeparam>
        /// <param name="min">minima value accepted</param>
        /// <param name="max">maximal value accepted</param>
        /// <param name="value">the value to validate</param>
        /// <param name="message">message thrown if value is out of range</param>
        void ValidateValueRange<T>(T min, T max, T value, string message) where T : IComparable;

        /// <summary>
        /// Throws ArgumentException if given value is not consisted only of latin letters
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="message">Message to throw if value is not valid</param>
        void ValidateStringLatinLetters(string value, string message);

        /// <summary>
        /// ThrowsArgumentNullExcaption when a given object is null
        /// </summary>
        /// <param name="obj">Object to validate</param>
        /// <param name="message">Message to throw if object is null</param>
        void ValidateNullObject(object obj, string message);
    }
}