using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public short StreetNumber { get; set; }
        public float Rating { get; set; }
        public float MinimumOrderValue { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }

}
