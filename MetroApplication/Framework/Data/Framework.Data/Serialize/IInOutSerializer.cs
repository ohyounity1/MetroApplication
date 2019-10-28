using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Helper interface which provides interface <see cref="IInSerializer"/> 
    /// and <see cref="IOutSerializer"/> for both reading/writing
    /// </summary>
    public abstract class InOutSerializer<T> : IInSerializer<T>, IOutSerializer<T>
    {
        /// <summary>
        /// The data payload to be read out or written back
        /// </summary>
        public abstract T Data { get; set; }

        /// <summary>
        /// Implement to load the data into the Data property from the given data source passed in
        /// </summary>
        /// <param name="reader">Where to read the data source</param>
        /// <returns>True/false as to whether the load succeeds</returns>
        public abstract bool Load(TextReader reader);
        /// <summary>
        /// Implement to save the data from the Data property into the given data source passed in
        /// </summary>
        /// <param name="writer">The location where the data will be written back into</param>
        /// <returns>True/false as to whether the save succeeds</returns>
        public abstract bool Save(TextWriter writer);
    }
}
