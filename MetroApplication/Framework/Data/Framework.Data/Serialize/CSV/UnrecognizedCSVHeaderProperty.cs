namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Error for when the CSV header is not recognized
    /// </summary>
    public class UnrecognizedCSVHeaderProperty
    {

        /// <summary>
        /// Initializes a new instance of <see cref="UnrecognizedCSVHeaderProperty"/>
        /// </summary>
        /// <param name="propertyName">Property that was not recognized</param>
        public UnrecognizedCSVHeaderProperty(string propertyName) => PropertyName = propertyName;

        /// <summary>
        /// Property name not recognized
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Format for the error string
        /// </summary>
        /// <returns>Error string</returns>
        public override string ToString() => "Unrecognized CSV header property: " + PropertyName;
    }
}
