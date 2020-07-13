using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Logging
{
    class EventLogDemo
    {
        public static void Logger(Exception ex)
        {
            StringBuilder sbException = new StringBuilder();
            sbException.AppendLine("Exception: " + ex.GetType().Name + Environment.NewLine);
            sbException.AppendLine("Message: " + ex.Message + Environment.NewLine);
            sbException.AppendLine("Trace:" + Environment.NewLine + ex.StackTrace);
            sbException.AppendLine("-------------------------" + Environment.NewLine);

            Exception innerEx = ex.InnerException;

            while (innerEx != null)
            {
                sbException.AppendLine("Inner Exception: " + innerEx.GetType().Name);
                sbException.AppendLine("Message: " + innerEx.Message + Environment.NewLine);
                sbException.AppendLine("Trace:" + Environment.NewLine + innerEx.StackTrace);
                sbException.AppendLine("-------------------------" + Environment.NewLine);

                innerEx = innerEx.InnerException;
            }

            if (EventLog.SourceExists("DisposableCode"))
            {
                EventLog log = new EventLog("DisposableCode");
                log.Source = "DisposableCode";
                log.WriteEntry(sbException.ToString(), EventLogEntryType.Error);
            }
            else
            {
                EventLog.CreateEventSource("DisposableCode", "DisposableCodeLog");
                EventLog log = new EventLog();
                log.Source = "DisposableCode";
                log.WriteEntry(sbException.ToString(), EventLogEntryType.Error);
            }
        }
    }
}
