using System.Diagnostics;

namespace Framework.Utility.Logging
{
    public class DebugConsoleLogger : ILogger
    {
        public void LogString(string toLog) => Debug.WriteLine(toLog);
    }
}
