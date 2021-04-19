namespace deep.wefood.api.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public float? MinimumOrderValue { get; set; }
    }
}