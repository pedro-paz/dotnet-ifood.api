using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Presentation.Dto
{
    public class ClientDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }


    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}