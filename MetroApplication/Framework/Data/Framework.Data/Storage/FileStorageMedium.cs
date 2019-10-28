using System.IO;

using Framework.Data.Serialize;

using OurException = Framework.Patterns.Exception.Exception;

namespace Framework.Data.Storage
{
    /// <summary>
    /// Implementation of <see cref="IStorageMedium"/> which stores into a file
    /// </summary>
    public class FileStorageMedium : IStorageMedium
    {
        /// <summary>
        /// Name of the file to store data into
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// Whether the file must exist
        /// </summary>
        private readonly bool _mustExist;

        /// <summary>
        /// Initializes a new instance of <see cref="FileStorageMedium"/>
        /// </summary>
        /// <param name="fileName">Name of the file being used for storage</param>
        /// <param name="mustExist">Whether the file must exist, false by default</param>
        public FileStorageMedium(string fileName, bool mustExist = false)
        {
            _fileName = fileName;
            _mustExist = mustExist;
        }

        /// <summary>
        /// <see cref="IStorageMedium.Save(IOutSerializer)"/>
        /// </summary>
        /// <param name="serializer">Where to save data into</param>
        public void Save(IOutSerializer serializer)
        {
            // Prepare the file for writing out to
            using var stream = new FileStream(_fileName, FileMode.Create);
            // Writer
            using var writer = new StreamWriter(stream);
            serializer.Save(writer);
        }

        /// <summary>
        /// <see cref="IStorageMedium.Load(IInSerializer)"/>
        /// </summary>
        /// <param name="serializer">Where to load data from</param>
        public void Load(IInSerializer serializer)
        {
            if (_mustExist && !File.Exists(_fileName))
                throw OurException.Throw(new RequiredFileMissingException(_fileName));
            else if (!_mustExist && !File.Exists(_fileName))
                return;

            // Prepare file to be read from
            using var stream = new FileStream(_fileName, FileMode.Open);
            // Reader
            using var reader = new StreamReader(stream);
            serializer.Load(reader);
        }
    }
}
