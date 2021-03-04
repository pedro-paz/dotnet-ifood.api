using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int IdUser { get; set; }
        public string Guid { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }

    }
}