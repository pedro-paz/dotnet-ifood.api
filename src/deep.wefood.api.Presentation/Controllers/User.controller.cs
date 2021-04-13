using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Authentication;
using deep.wefood.api.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace deep.wefood.api.Presentation
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IServiceUser _serviceUser;
        private IServiceAuthentication _serviceAuthentication;
        private IMapper _mapper;

        public UserController(IServiceUser serviceUser, IMapper mapper, IServiceAuthentication serviceAuthentication)
        {
            _serviceAuthentication = serviceAuthentication;
            _serviceUser = serviceUser;
            _mapper = mapper;
        }

        #region GET
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            var user = _serviceUser.FindByEmail(email);
            var dto = _mapper.Map<UserDto>(user);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }
        #endregion


        #region POST
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserDto value)
        {
            var user = _serviceUser.FindByEmail(value.Email);
            if (user != null)
                return Conflict("Email already in use");

            user = _mapper.Map<User>(value);
            _serviceUser.Add(user);

            var authenticationDto = _serviceAuthentication.CreateToken(user);

            return Ok(authenticationDto);
        }
        #endregion

        #region PUT
        [HttpPut]
        [Authorize]
        public IActionResult Put(UserDto value)
        {
            var user = _mapper.Map<User>(value);
            _serviceUser.Update(user);
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete("{guid}")]
        [Authorize]
        public IActionResult Delete(string guid)
        {
            _serviceUser.Delete(guid);
            return Ok();
        }
        #endregion
    }
}