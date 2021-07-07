using Etms.Api.Core.Entities;
using Etms.Api.Core.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etms.Api.Core.RepositoryInterfaces
{
    public interface ITimeLogRepository : IRepository<TimeLog>
    {
        TimeLog GetLastLogByUser(User user);
    }
}
