using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class CompanyDetail : Company
    {
        public string Description { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public short StreetNumber { get; set; }
        public virtual ICollection<ProductDetail> Products { get; set; }

    }

}
