using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int IdCompany { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public virtual ICollection<ComplementGroup> ComplementGroups { get; set; }

    }
}
