using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class CompanyDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public float? MinimumOrderValue { get; set; }
    }


}