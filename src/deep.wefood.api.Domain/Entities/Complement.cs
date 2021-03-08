namespace deep.wefood.api.Domain.Entities
{
    public class Complement : BaseEntity
    {
        public int IdComplementGroup { get; set; }
        public string Guid { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
