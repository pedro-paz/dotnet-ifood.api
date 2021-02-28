using System;

namespace deep.ifood.api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}
