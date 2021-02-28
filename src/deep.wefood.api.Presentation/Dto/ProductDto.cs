using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ProductDto
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<IngredientDto> Ingredientes { get; set; }
    }

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}