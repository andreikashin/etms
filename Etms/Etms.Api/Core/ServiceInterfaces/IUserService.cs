using System.Collections.Generic;
using Etms.Api.Core.Entities;

namespace Etms.Api.Core.ServiceInterfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);

        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}