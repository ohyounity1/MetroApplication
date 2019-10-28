using Framework.Data.Serialize;

namespace Framework.Data.Storage
{
    public class Storable<T>
    {
        /// <summary>
        /// The storage medium
        /// </summary>
        private readonly IStorageMedium _storageMedium;
        /// <summary>
        /// Serializer, should have no constructor parameters
        /// </summary>
        private readonly InOutSerializer<T> _serializer;

        /// <summary>
        /// Initializes a new instance of <see cref="Storable{S}"/> with a specific medium
        /// </summary>
        /// <param name="storageMedium"></param>
        public Storable(IStorageMedium storageMedium, InOutSerializer<T> serializer)
        {
            _storageMedium = storageMedium;
            _serializer = serializer;
        }

        /// <summary>
        /// Access to the serializer, which will have the data loaded into it
        /// </summary>
        public T Data
        {
            get => _serializer.Data;
            set => _serializer.Data = value;
        }

        /// <summary>
        /// Save from the data into the storage medium
        /// </summary>
        public void Save() => _storageMedium.Save(_serializer);

        /// <summary>
        /// Load from the storage into the data
        /// </summary>
        public void Load() => _storageMedium.Load(_serializer);
    }
}
