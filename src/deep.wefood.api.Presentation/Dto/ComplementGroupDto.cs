using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ComplementGroupDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public short Minimum { get; set; }
        public short Maximum { get; set; }
        public ICollection<ComplementDto> Complements { get; set; }
    }


    public class ComplementGroupProfile : Profile
    {
        public ComplementGroupProfile()
        {
            CreateMap<ComplementGroup, ComplementGroupDto>()
                .ReverseMap();
        }
    }
}