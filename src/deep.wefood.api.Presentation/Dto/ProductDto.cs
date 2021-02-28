using System.Collections.Generic;

namespace deep.wefood.api.Presentation.Dto
{
    public class ProductDto
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<IngredientDto> Ingredientes { get; set; }


    }
}