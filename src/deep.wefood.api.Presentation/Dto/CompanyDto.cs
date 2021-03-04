using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class CompanyDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }

    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}