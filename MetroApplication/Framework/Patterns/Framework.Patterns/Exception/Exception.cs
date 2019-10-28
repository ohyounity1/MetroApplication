namespace Framework.Patterns.Exception
{
    /// <summary>
    /// Generic exception class allowing user to throw any type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Type of data to throw</typeparam>
    public class Exception<T> : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Exception{T}"/>
        /// </summary>
        /// <param name="details"></param>
        public Exception(T details) => Details = details;

        /// <summary>
        /// Access to the details
        /// </summary>
        public T Details { get; }

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>Display details of the exception</returns>
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    /// <summary>
    /// Helper class for throwing exception with the given detail class
    /// </summary>
    public static class Exception
    {
        /// <summary>
        /// Helper method to throw exception with given payload detail class
        /// </summary>
        /// <typeparam name="T">Payload detail class to throw with the exception</typeparam>
        /// <param name="input">Exception details</param>
        /// <returns><see cref="Exception{T}'"/></returns>
        public static Exception<T> Throw<T>(T input) => new Exception<T>(input);
    }
}
