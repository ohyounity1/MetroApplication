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

        public static Exception<T> Throw(T input) => new Exception<T>(input);
    }

    public static class Exception
    {
        public static Exception<T> Throw<T>(T input) => new Exception<T>(input);
    }
}
