using Etms.Api.Core.Entities;

namespace Etms.Api.Core.ServiceInterfaces
{
    public interface ITimeLogService
    {
        void Insert(TimeLog log);
        void Modify(TimeLog log);
        TimeLog FindById(int id);
        void UpdateTimeLog();
    }
}
