#define VISION_LOG

#if !SILVERLIGHT

namespace NLog.Targets
{
    using System;
    using System.Diagnostics;
    using Vision;

    /// <summary>
    /// Sends log messages through Vision Data source into Vision DB logs
    /// </summary>
    /// 
    [Target("VisionLog")]
    public sealed class VisionLogTarget : TargetWithLayout
    {
        /// <summary>
        /// Writes the specified logging event to the <see cref="System.Diagnostics.Trace"/> facility.
        /// If the log level is greater than or equal to <see cref="LogLevel.Error"/> it uses the
        /// <see cref="System.Diagnostics.Trace.Fail(string)"/> method, otherwise it uses
        /// <see cref="System.Diagnostics.Trace.Write(string)" /> method.
        /// </summary>
        /// <param name="logEvent">The logging event.</param>
        protected override void Write(LogEventInfo logEvent)
        {
            //string msg = "";
            //foreach(var obj in logEvent.Properties)
            //{
            //    msg += obj.Key + ": " + obj.Value + " | ";
            //}

            WriteMessageToDatabase(logEvent.Properties);
        }

        /// <summary>
        /// returns null if key not found
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        private object getValueForKey(string key, System.Collections.Generic.IDictionary<object, object> dict)
        {
            object outObj;
            if (dict.TryGetValue(key, out outObj))
            {
                if (outObj.GetType() == typeof(DateTime))
                    return ((DateTime)outObj);
                else if (outObj.GetType() == typeof(string))
                    return outObj.ToString();
                else if (outObj.GetType() == typeof(int))
                    return (int)outObj;
                else
                    return outObj;
            }
            else return null;
        }

        private void WriteMessageToDatabase(System.Collections.Generic.IDictionary<object, object> dict)
        {
            int result = 0;
            using (VisionLogDBModel dbContext = new VisionLogDBModel())
            {
                GLOBAL_AUDIT globalAudit = new GLOBAL_AUDIT();

                globalAudit.ENTITY = getValueForKey("ENTITY", dict) as string;
                globalAudit.ACTION = getValueForKey("ACTION", dict) as string;
                globalAudit.PRIMARY_KEY_VALS = getValueForKey("PRIMARY_KEY_VALS", dict) as string;
                globalAudit.CHANGED_COLS_VAL = getValueForKey("CHANGED_COLS_VAL", dict) as string;
                globalAudit.CREATED_BY = getValueForKey("CREATED_BY", dict) as string;
                globalAudit.CREATED_ON = (DateTime)getValueForKey("CREATED_ON", dict);
                globalAudit.UPDATED_BY = getValueForKey("UPDATED_BY", dict) as string;
                globalAudit.UPDATED_ON = (DateTime)getValueForKey("UPDATED_ON", dict);
                globalAudit.LOG_TYPE_ID = getValueForKey("LOG_TYPE_ID", dict) as string;
                globalAudit.RESULT = (int)getValueForKey("RESULT", dict);
                globalAudit.EVENT_ORIGIN = getValueForKey("EVENT_ORIGIN", dict) as string;
                globalAudit.DESCRIPTION = getValueForKey("DESCRIPTION", dict) as string;

                //globalAudit.ENTITY =  "entity";
                //globalAudit.ACTION = "action_undefined";
                //globalAudit.PRIMARY_KEY_VALS = message;
                //globalAudit.CHANGED_COLS_VAL = "col vals";
                //globalAudit.CREATED_BY = "username";
                //globalAudit.CREATED_ON = DateTime.Now;
                //globalAudit.UPDATED_BY = "username";
                //globalAudit.UPDATED_ON = DateTime.Now;
                //globalAudit.LOG_TYPE_ID = "logtype_undefined";
                //globalAudit.RESULT = 1;
                //globalAudit.EVENT_ORIGIN = "none";
                //globalAudit.DESCRIPTION= "none";

                dbContext.GLOBAL_AUDIT.Add(globalAudit);
                result = dbContext.SaveChanges();

            }
        }
    }
}

#endif
