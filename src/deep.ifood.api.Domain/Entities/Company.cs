using System.Collections.Generic;

namespace deep.ifood.api.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<User> Usuarios { get; set; }

    }

}
