namespace Framework.Data.Storage
{
    public class RequiredFIleMissingException : System.Exception
    {
        public string FileName { get; }

        public RequiredFIleMissingException(string fileName) => FileName = fileName;

        public override string ToString() => $"Required file {FileName} is missing!";
    }
}
