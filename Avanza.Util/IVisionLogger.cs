using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Avanza.Util
{
    public interface IVisionLogger
    {
        LogEventInfo GetLogEvent(LogLevel level, string loggerName, string message,
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
            string Description);
    }
}
