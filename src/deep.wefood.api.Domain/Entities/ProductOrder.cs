namespace deep.wefood.api.Domain.Entities
{
    public class ProductOrder : BaseEntity
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public virtual Order Pedido { get; set; }
        public virtual Product Produto { get; set; }
    }
}
