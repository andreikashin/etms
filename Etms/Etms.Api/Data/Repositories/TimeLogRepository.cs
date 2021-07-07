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

        public TimeLogRepository(DbContext context) : base(context)
        { }

        public TimeLog GetLastLogByUser(User user)
        {
            return AppDbContext
               .TimeLogs
               .Where(x => x.UserId == user.Id)
               .Include(x => x.User)
               .LastOrDefault();
        }
    }
}
