using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class CompanyDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public float? MinimumOrderValue { get; set; }
        public short StreetNumber { get; set; }
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