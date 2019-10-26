using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Helper interface which provides interface <see cref="IInSerializer"/> 
    /// and <see cref="IOutSerializer"/> for both reading/writing
    /// </summary>
    public abstract class InOutSerializer<T> : IInSerializer<T>, IOutSerializer<T>
    {
        public abstract T Data { get; set; }

        public abstract bool Load(TextReader reader);
        public abstract bool Save(TextWriter writer);
    }
}
