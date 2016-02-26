using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;

namespace Avanza.Util
{
    public sealed class APINLogger : ITraceWriter, IVisionLogger
    {
        private static readonly Logger classLogger = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<Dictionary<TraceLevel, Action<object>>> loggingMap =
            new Lazy<Dictionary<TraceLevel, Action<object>>>(() => new Dictionary<TraceLevel, Action<object>>
                {
                    {TraceLevel.Info, classLogger.Info},
                    {TraceLevel.Debug, classLogger.Debug},
                    {TraceLevel.Error, classLogger.Error},
                    {TraceLevel.Fatal, classLogger.Fatal},
                    {TraceLevel.Warn, classLogger.Warn}
                });

        private Dictionary<TraceLevel, Action<object>> Logger
        {
            get { return loggingMap.Value; }
        }

        public void Trace(System.Net.Http.HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                if (traceAction != null && traceAction.Target != null)
                {
                    category = category + Environment.NewLine + "Action Parameters : " + JsonConvert.SerializeObject(traceAction.Target);
                }
                var record = new TraceRecord(request, category, level);
                if (traceAction != null) traceAction(record);
                Log(record);
            }
        }

        private void Log(TraceRecord record)
        {
            var message = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append("").Append(record.Message + Environment.NewLine);

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append("Method: " + record.Request.Method + Environment.NewLine);

                if (record.Request.RequestUri != null)
                    message.Append("").Append("URL: " + record.Request.RequestUri + Environment.NewLine);

                if (record.Request.Headers != null && record.Request.Headers.Contains("Token") && record.Request.Headers.GetValues("Token") != null && record.Request.Headers.GetValues("Token").FirstOrDefault() != null)
                    message.Append("").Append("Token: " + record.Request.Headers.GetValues("Token").FirstOrDefault() + Environment.NewLine);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append("").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);


            //Logger[record.Level](Convert.ToString(message) + Environment.NewLine);
            this.logMessage(LogLevel.Info, LogManager.GetClassFullName(),
                "message", this.GetType().Name, "action_undefined", "no prim keys", "no cols",
                Environment.UserName, DateTime.Now,Environment.UserName, DateTime.Now, Environment.MachineName,
                "logtype_undefined", 1,LogManager.GetClassFullName(),Convert.ToString(message));
        }

        public LogEventInfo GetLogEvent(LogLevel level, string loggerName, string message, string Entity, string Action, string PrimaryKeyVals, string ChangedColVals, string CreatedBy, DateTime CreatedOn, string UpdateBy, DateTime UpdatedOn, string MachineName, string LogTypeID, int Result, string EventOrigin, string Description)
        {
            var logEvent = new LogEventInfo(level, loggerName, message);

            logEvent.Properties["ENTITY"] = Entity;
            logEvent.Properties["ACTION"] = Action;
            logEvent.Properties["PRIMARY_KEY_VALS"] = PrimaryKeyVals;
            logEvent.Properties["CHANGED_COLS_VAL"] = ChangedColVals;
            logEvent.Properties["CREATED_ON"] = CreatedOn;
            logEvent.Properties["CREATED_BY"] = CreatedBy;
            logEvent.Properties["UPDATED_ON"] = UpdatedOn;
            logEvent.Properties["UPDATED_BY"] = UpdateBy;
            logEvent.Properties["WINDOWS_CREATED_BY"] = "";
            logEvent.Properties["WINDOWS_UPDATED_BY"] = "";
            logEvent.Properties["MACHINE_NAME"] = MachineName;
            logEvent.Properties["LOG_TYPE_ID"] = LogTypeID;
            logEvent.Properties["RESULT"] = Result;
            logEvent.Properties["EVENT_ORIGIN"] = EventOrigin;
            logEvent.Properties["DESCRIPTION"] = Description;

            return logEvent;
        }
    }
}