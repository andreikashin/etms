using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Etms.Api.Data.Repositories
{
    using Core.Entities;
    using Core.Interfaces.Repository;
    using Data.Repositories.Base;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;

        public UserRepository(DbContext context) : base(context)
        { }

        public IEnumerable<User> GetUsersWithRole()
        {
            return AppDbContext
               .Users
               .Include(u => u.Role);
        }
    }
}