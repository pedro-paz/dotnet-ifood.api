using AutoMapper;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deep.wefood.api.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private IServiceAuthentication _serviceAuthentication;
        private IServiceUser _serviceUser;
        private IMapper _mapper;

        public Authentication(IServiceUser serviceUser, IMapper mapper, IServiceAuthentication serviceAuthentication)
        {
            _serviceAuthentication = serviceAuthentication;
            _serviceUser = serviceUser;
            _mapper = mapper;
        }

        #region GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string email, string password)
        {
            var user = _serviceUser.Authenticate(email, password);
            if (user == null) return Forbid();

            var token = _serviceAuthentication.CreateToken(user);
            return Ok(token);
        }
        #endregion



    }
}