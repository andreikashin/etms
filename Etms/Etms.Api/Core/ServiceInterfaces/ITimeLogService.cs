using Etms.Api.Core.Entities;
using System.Collections.Generic;

namespace Etms.Api.Core.ServiceInterfaces
{
    public interface ITimeLogService
    {
        void Insert(TimeLog log);
        void Modify(TimeLog log);
        TimeLog FindById(int id);
        void UpdateTimeLog();
        List<TimeLog> GetAll();
        List<TimeLog> GetAllByUser(User user);
        void DeleteById(int id);
    }
}
