using Etms.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etms.Api.Core.Helpers
{
    public static class TimeLogHelper
    {
        public static bool CanStoreLog(TimeLog log, TimeLog lastLog)
        {
            var result = false;

            result = lastLog.EndTime != null &&
                     lastLog.EndTime > default(DateTimeOffset) &&
                     lastLog.EndTime < log.StartTime;

            return result;
        }
    }
}
