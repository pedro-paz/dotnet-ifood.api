using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Presentation.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace deep.wefood.api.Presentation.Authentication
{
    public interface IServiceAuthentication
    {
        AuthenticationDto CreateToken(User user);
    }

    public class ServiceAuthentication : IServiceAuthentication
    {
        private IConfiguration _configuration;

        public ServiceAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthenticationDto CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.GetValue<string>("Secret");
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationDto()
            {
                Token = tokenHandler.WriteToken(token),
                Expires = tokenDescriptor.Expires ?? DateTime.Now
            };
        }
    }
}