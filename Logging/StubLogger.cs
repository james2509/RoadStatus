using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    /// <summary>
    /// Logger implementation that does nothing
    /// This should be replaced with an actual logging implementation (e.g. NLog)
    /// </summary>
    public class StubLogger : ILogger
    {
        public void LogError(string error)
        {
            
        }

        public void LogException(Exception e)
        {
            
        }

        public void LogInfo(string message)
        {
            
        }
    }
}
