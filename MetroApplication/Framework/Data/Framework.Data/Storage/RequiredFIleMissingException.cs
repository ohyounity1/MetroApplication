namespace Framework.Data.Storage
{
    /// <summary>
    /// Exception details from when a required file is mistting
    /// </summary>
    public class RequiredFileMissingException
    {
        /// <summary>
        /// File name that was missing
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="RequiredFileMissingException"/>
        /// </summary>
        /// <param name="fileName">File that is missing</param>
        public RequiredFileMissingException(string fileName) => FileName = fileName;

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        /// <returns>Detail string of the exception details</returns>
        public override string ToString() => $"Required file {FileName} is missing!";
    }
}
