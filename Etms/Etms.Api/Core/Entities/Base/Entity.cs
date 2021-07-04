using System;

namespace Etms.Api.Core.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}