namespace deep.wefood.api.Domain.Entities
{
    public class ProductOrder : BaseEntity
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
