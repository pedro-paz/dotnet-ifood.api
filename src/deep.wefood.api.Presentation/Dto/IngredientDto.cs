using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class IngredientDto
    {
        public string Nome { get; set; }
        public string Guid { get; set; }
        public string Descricao { get; set; }
    }

    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
        }
    }
}