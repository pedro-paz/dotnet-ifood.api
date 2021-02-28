using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int IdCliente { get; set; }
        public virtual Client Cliente { get; set; }
        public virtual ICollection<ProductOrder> PedidoProdutos { get; set; }

    }
}