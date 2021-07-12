using Etms.Api.Core.Entities;
using Etms.Api.Core.Helpers;
using Etms.Api.Core.RepositoryInterfaces;
using Etms.Api.Core.ServiceInterfaces;
using System;

namespace Etms.Api.Services
{
    public class TimeLogService : ITimeLogService
    {
        public ITimeLogRepository TimeLogs { get; set; }

        public void Insert(TimeLog log)
        {
            var lastLog = TimeLogs.GetLastLogByUser(log.User);

            if (lastLog.EndTime is null)
            {
                // task is ongoing
            }

            if(!TimeLogHelper.CanStoreLog(log, lastLog))
            {
                // time overlap
            }
        }
    }
}
