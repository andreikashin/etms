using Etms.Api.Core.Interfaces.Repository.Base;
using Etms.Api.Core.Entities;
using System.Collections.Generic;

namespace Etms.Api.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUsersWithRole();
    }
}