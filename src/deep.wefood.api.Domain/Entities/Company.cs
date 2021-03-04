using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

    }

}
