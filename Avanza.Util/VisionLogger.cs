using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Avanza.Util
{
    public static class VisionLogger
    {
        private static string _loggerName = "NLogLogger";

        private static Logger _logger
        {
            get
            {
                return LogManager.GetLogger(_loggerName);
            }
        }

        //private static Logger _logger = GetLoggingService();

        //private static Logger GetLoggingService()
        //{
        //    Logger logger = LogManager.GetCurrentClassLogger();
        //    return logger;
        //}

        public static void logMessage(this IVisionLogger logabble, LogLevel level, string loggerName, string message,
            string Entity,
            string Action,
            string PrimaryKeyVals,
            string ChangedColVals,
            string CreatedBy,
            DateTime CreatedOn,
            string UpdateBy,
            DateTime UpdatedOn,
            string MachineName,
            string LogTypeID,
            int Result,
            string EventOrigin,
            string Description)
        {
            _loggerName = loggerName;
            _logger.Log(logabble.GetLogEvent(level, loggerName, message, Entity, Action, PrimaryKeyVals,
                ChangedColVals, CreatedBy, CreatedOn, UpdateBy, UpdatedOn, MachineName, LogTypeID, Result, EventOrigin, Description));
        }

    }
}
