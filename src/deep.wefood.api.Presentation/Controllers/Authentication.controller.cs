using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace deep.wefood.api.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private IServiceUser _serviceUser;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public Authentication(IServiceUser serviceUser, IConfiguration configuration, IMapper mapper)
        {
            _serviceUser = serviceUser;
            _configuration = configuration;
            _mapper = mapper;
        }

        #region GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string email, string password)
        {
            var user = _serviceUser.Authenticate(email, password);
            if (user == null) return Unauthorized();

            var token = CreateJWT(user);
            return Ok(token);
        }
        #endregion


        #region POST
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromForm] UserDto value)
        {
            var user = _mapper.Map<User>(value);
            _serviceUser.Add(user);
            user = _serviceUser.Authenticate(value.Email, value.Password);

            if (user == null)
                return Conflict("Email already in use");

            var authenticationDto = CreateJWT(user);
            return Ok(authenticationDto);
        }
        #endregion


        private AuthenticationDto CreateJWT(User user)
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