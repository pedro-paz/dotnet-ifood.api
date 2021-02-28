using System.Collections.Generic;
using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace deep.wefood.api.Presentation
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IServiceCompany _serviceCompany;
        private IServiceUser _serviceUser;
        private IMapper _mapper;

        public UserController(IServiceUser serviceUser, IServiceCompany serviceCompany, IMapper mapper)
        {
            _serviceCompany = serviceCompany;
            _serviceUser = serviceUser;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var user = _serviceUser.FindByGuid(guid);
            var dto = _mapper.Map<UserDto>(user);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [Route("~/company/{companyGuid}/users"), HttpGet]
        public IActionResult GetByCompany(string companyGuid)
        {
            var users = _serviceCompany.FindUsers(companyGuid);
            var dto = _mapper.Map<IEnumerable<UserDto>>(users);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }
        #endregion

        #region POST
        public IActionResult Post([FromBody] UserDto value)
        {
            var entity = _mapper.Map<User>(value);
            _serviceUser.Add(entity);
            return Ok();
        }
        #endregion

        #region PUT
        [HttpDelete("{value}")]
        public IActionResult Put(UserDto value)
        {
            var user = _mapper.Map<User>(value);
            _serviceUser.Add(user);
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            _serviceUser.Delete(guid);
            return Ok();
        }
        #endregion
    }
}