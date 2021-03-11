using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ComplementGroupDto
    {
        public string Guid { get; set; }
        public short Minimum { get; set; }
        public short Maximum { get; set; }
        public virtual IEnumerable<ComplementDto> Complements { get; set; }
    }


    public class ComplementGroupProfile : Profile
    {
        public ComplementGroupProfile()
        {
            CreateMap<ComplementGroup, ComplementGroupProfile>().ReverseMap();
        }
    }
}