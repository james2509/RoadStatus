using System;

namespace Logging
{
    /// <summary>
    /// Interface to provide logging functionality
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log information messages
        /// </summary>
        void LogInfo(string message);

        /// <summary>
        /// Log error messages
        /// </summary>
        void LogError(string error);

        /// <summary>
        /// Log Exception messages
        /// </summary>
        void LogException(Exception e);
    }
}
