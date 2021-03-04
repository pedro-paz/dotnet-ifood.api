using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
