using System.Threading.Tasks;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
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
        public IActionResult Post([FromBody] User value)
        {

            return Ok();
        }
    }
}