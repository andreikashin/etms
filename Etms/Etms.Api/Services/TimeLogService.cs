using Etms.Api.Core.Entities;
using Etms.Api.Core.Helpers;
using Etms.Api.Core.Interfaces.Repository;
using Etms.Api.Core.RepositoryInterfaces;
using Etms.Api.Core.ServiceInterfaces;
using Microsoft.Extensions.Options;
using System;

namespace Etms.Api.Services
{
    public class TimeLogService : ITimeLogService
    {
        public ITimeLogRepository TimeLogs { get; set; }

        public TimeLogService(
            ITimeLogRepository timeLogs)
        {
            TimeLogs = timeLogs;
        }

        public void Insert(TimeLog log)
        {
            if (string.IsNullOrWhiteSpace(log.Description))
            {
                throw new Exception("No description");
            }

            //var lastLog = TimeLogs.GetPrevUserLogByCurrentLog(log);
            var prevLog = TimeLogs.GetPrevUserLogByCurrentLog(log);
            var nextLog = TimeLogs.GetPrevUserLogByCurrentLog(log);

            if (prevLog is null)
            {
                TimeLogs.Add(log);
                return;
            }

            if (prevLog.EndTime is null)
            {
                // task is ongoing
                throw new Exception("you have uncompleted task");
            }

            if (nextLog != null && log.EndTime is null)
            {
                // cannot create ongoing task when next task already present
                throw new Exception("cannot create ongoing task here");
            }

            if (!TimeLogHelper.CanStoreLog(log, prevLog))
            {
                // time overlap
                throw new Exception("you cannot store task");
            }
        }

        public void Modify(TimeLog log)
        {
            if (log.EndTime is null)
            {
                throw new Exception("Missing end time");
            }

            var prevLog = TimeLogs.GetPrevUserLogByCurrentLog(log);
            var nextLog = TimeLogs.GetPrevUserLogByCurrentLog(log);

            if (log.StartTime < prevLog.EndTime)
            {
                throw new Exception("Start time overlaps");
            }

            if (nextLog != null && 
                log.EndTime > nextLog.StartTime)
            {
                throw new Exception("End time overlaps");
            }

            TimeLogs.Update(log);
        }
    }
}
