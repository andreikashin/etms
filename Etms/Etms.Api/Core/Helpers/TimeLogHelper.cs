using Etms.Api.Core.Entities;

namespace Etms.Api.Core.Helpers
{
    public static class TimeLogHelper
    {
        public static bool CanStoreLog(TimeLog log, TimeLog prevLog)
        {
            var result = prevLog.EndTime != null &&
                         log.EndTime > log.StartTime &&
                         prevLog.EndTime <= log.StartTime;

            return result;
        }
    }
}
