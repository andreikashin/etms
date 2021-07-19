using Etms.Api.Core.Entities;
using Etms.Api.Core.RepositoryInterfaces;
using Etms.Api.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Etms.Api.Data.Repositories
{
    public class TimeLogRepository : Repository<TimeLog>, ITimeLogRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;

        public TimeLogRepository(AppDbContext context) : base(context)
        { }

        public TimeLog GetLastLogByUser(User user)
        {
            return AppDbContext
               .TimeLogs
               .Where(x => x.UserId == user.Id)
               .Include(x => x.User)
               .ToList()
               .LastOrDefault();
        }

        public TimeLog GetPrevUserLogByCurrentLog(TimeLog log)
        {
            return AppDbContext
               .TimeLogs
               .Include(x => x.User)
               .Where(x => x.UserId == log.UserId)
               .ToList()
               .Where(x => x.EndTime <= log.StartTime)
               .OrderBy(x => x.EndTime)
               .LastOrDefault();
        }

        public TimeLog GetNextUserLogByCurrentLog(TimeLog log)
        {
            return AppDbContext
               .TimeLogs
               .Include(x => x.User)
               .Where(x => x.UserId == log.UserId)
               .ToList()
               .Where(x => x.StartTime >= log.EndTime)
               .OrderBy(x => x.StartTime)
               .FirstOrDefault();
        }
    }
}
