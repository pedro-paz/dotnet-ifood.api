using System;

namespace deep.wefood.api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime RegisterDate { get; private set; }

    }
}
