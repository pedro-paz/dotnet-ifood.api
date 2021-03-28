using System;

namespace deep.wefood.api.Presentation.Dto
{
    public class AuthenticationDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}