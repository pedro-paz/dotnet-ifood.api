using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class CompanyDetailDto : CompanyDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public short StreetNumber { get; set; }
    }

    public class CompanyDetailProfile : Profile
    {
        public CompanyDetailProfile()
        {
            CreateMap<CompanyDetail, CompanyDetailDto>().ReverseMap().IncludeAllDerived();
            CreateMap<Company, CompanyDto>().ReverseMap().IncludeAllDerived();
        }
    }
}