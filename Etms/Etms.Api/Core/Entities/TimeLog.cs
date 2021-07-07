using Etms.Api.Core.Entities.Base;
using System;

namespace Etms.Api.Core.Entities
{
    public class TimeLog : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }
}
