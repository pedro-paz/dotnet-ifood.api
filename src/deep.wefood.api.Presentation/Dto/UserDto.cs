using AutoMapper;
using deep.wefood.api.Domain.Entities;
using Newtonsoft.Json;

namespace deep.wefood.api.Presentation.Dto
{
    public class UserDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonProperty(nameof(UserDto.Password), NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}