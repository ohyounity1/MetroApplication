using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Interface for a serializer which reads from a stream and creates a type
    /// </summary>
    public interface IInSerializer
    {
        /// <summary>
        /// Load type from a stream
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        bool Load(TextReader reader);
    }

    /// <summary>
    /// Addition to the <see cref="IInSerializer"/> that adds access to the Data payload
    /// </summary>
    /// <typeparam name="T">The type of the data to save out</typeparam>
    public interface IInSerializer<T> : IInSerializer
    {
        /// <summary>
        /// After loading the data, get the data from this location
        /// </summary>
        public T Data { get; }
    }
}
