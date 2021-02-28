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
        private IServiceUser serviceUser;

        public UserController(IServiceUser _serviceUser)
        {
            serviceUser = _serviceUser;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var usuario = serviceUser.FindByGuid(guid);
            return usuario == null ? Ok(JsonConvert.SerializeObject(usuario)) : NoContent();
        }

        [HttpPost("{value}")]
        public IActionResult Post([FromBody] UserDto value)
        {
            return Ok();
        }

        [HttpDelete("{value}")]
        public IActionResult Put([FromBody] UserDto value)
        {
            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            return Ok();
        }
    }
}