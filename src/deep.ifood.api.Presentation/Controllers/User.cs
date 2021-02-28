using System.Threading.Tasks;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace deep.ifood.api.Presentation
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IServiceUser serviceUsuario;

        public UserController(IServiceUser _serviceUsuario)
        {
            serviceUsuario = _serviceUsuario;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var usuario = serviceUsuario.FindByGuid(guid);
            return usuario == null ? Ok(JsonConvert.SerializeObject(usuario)) : NoContent();
        }

        [HttpPost("{value}")]
        public IActionResult Post([FromBody] User value)
        {

            return Ok();
        }
    }
}