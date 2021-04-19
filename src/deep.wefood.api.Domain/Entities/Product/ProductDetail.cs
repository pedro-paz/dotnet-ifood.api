using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class ProductDetail : Product
    {
        public int IdCompany { get; set; }
        public virtual CompanyDetail Company { get; set; }
        public virtual ICollection<ComplementGroup> ComplementGroups { get; set; }
    }
}
