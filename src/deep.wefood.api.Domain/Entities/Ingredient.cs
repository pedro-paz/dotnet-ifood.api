namespace deep.wefood.api.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public int IdCompany { get; set; }
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
    }
}
