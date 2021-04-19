using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ProductDetailDto : ProductDto
    {
        public string GuidCompany { get; set; }
        public virtual ICollection<ComplementGroupDto> ComplementGroups { get; set; }
    }

    public class ProductDetailProfile : Profile
    {
        public ProductDetailProfile()
        {

            CreateMap<ProductDetail, ProductDetailDto>()
                .ForMember(x => x.GuidCompany, opt => opt.MapFrom(x => x.Guid))
                .ReverseMap();
        }
    }
}