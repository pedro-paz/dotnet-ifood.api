namespace deep.wefood.api.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}