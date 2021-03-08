using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class ComplementGroup : BaseEntity
    {
        public string IdProduct { get; set; }
        public string Guid { get; set; }
        public short Minimum { get; set; }
        public short Maximum { get; set; }
        public virtual IEnumerable<Complement> Complements { get; set; }
    }
}