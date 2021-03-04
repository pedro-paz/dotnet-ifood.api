using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class IngredientDto
    {
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public string GuidCompany { get; set; }
    }

    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
        }
    }
}