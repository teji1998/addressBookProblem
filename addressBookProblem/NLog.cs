using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class NLog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(String message)
        {
            logger.Error(message);
        }
        public void LogWarn(String message)
        {
            logger.Warn(message);
        } 
    }
}
