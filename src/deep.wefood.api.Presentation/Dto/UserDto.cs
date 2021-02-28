using AutoMapper;
using deep.wefood.api.Domain.Entities;
using Newtonsoft.Json;

namespace deep.wefood.api.Presentation.Dto
{
    public class UserDto
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string GuidEmpresa { get; set; }

        [JsonProperty(nameof(UserDto.Senha), NullValueHandling = NullValueHandling.Ignore)]
        public string Senha { get; set; }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.GuidEmpresa, opt => opt.MapFrom(x => x.Empresa.Guid))
                .ForMember(x => x.Senha, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}