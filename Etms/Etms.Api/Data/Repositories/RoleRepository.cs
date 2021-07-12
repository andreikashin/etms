using Etms.Api.Core.Entities;
using Etms.Api.Core.Interfaces.Repository;
using Etms.Api.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etms.Api.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;

        public RoleRepository(AppDbContext context) : base(context)
        { }
    }
}
