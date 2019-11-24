using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Targets;

namespace GZIT.GZTimeTracker.Test
{
    public class LoggerFactory
    {
        public static ILogger GetLogger()
        {
            DebugTarget target = new DebugTarget();
            target.Layout = "${message}";

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

            

            return LogManager.GetLogger("Example");
            
        }
    }
}
