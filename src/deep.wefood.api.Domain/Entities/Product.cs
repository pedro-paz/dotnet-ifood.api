using System.Collections.Generic;

namespace deep.wefood.api.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int IdEmpresa { get; set; }
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual Company Empresa { get; set; }
        public virtual ICollection<Ingredient> Ingredientes { get; set; }

    }
}
