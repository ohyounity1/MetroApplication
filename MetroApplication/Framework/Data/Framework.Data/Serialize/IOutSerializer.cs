using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Interface for writing a type out into a stream
    /// </summary>
    public interface IOutSerializer
    {
        /// <summary>
        /// Save to the stream
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        bool Save(TextWriter writer);
    }

    /// <summary>
    /// Addition to the <see cref="IOutSerializer"/> interface that adds access to the data payload
    /// </summary>
    /// <typeparam name="T">Type to be serialized</typeparam>
    public interface IOutSerializer<T> : IOutSerializer
    {
        /// <summary>
        /// Store data here, then save out
        /// </summary>
        public T Data { set; }
    }
}
