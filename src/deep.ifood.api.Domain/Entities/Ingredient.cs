namespace deep.ifood.api.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public int IdEmpresa { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Guid { get; set; }
        public string Descricao { get; set; }

        public virtual Company Empresa { get; set; }
        public virtual Product Produto { get; set; }
    }
}
