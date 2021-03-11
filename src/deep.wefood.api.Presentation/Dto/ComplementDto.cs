using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ComplementDto
    {
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }

    public class ComplementProfile : Profile
    {
        public ComplementProfile()
        {
            CreateMap<Complement, ComplementDto>().ReverseMap();
        }
    }
}