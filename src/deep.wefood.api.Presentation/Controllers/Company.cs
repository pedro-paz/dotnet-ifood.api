using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace deep.wefood.api.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IServiceCompany _serviceCompany;
        private IMapper _mapper;

        public CompanyController(IServiceCompany serviceUser, IMapper mapper)
        {
            _serviceCompany = serviceUser;
            _mapper = mapper;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var company = _serviceCompany.FindByGuid(guid);
            var dto = _mapper.Map<CompanyDto>(company);
            return company != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromForm] CompanyDto value)
        {
            var entity = _mapper.Map<Company>(value);
            _serviceCompany.Add(entity);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromForm] CompanyDto value)
        {
            var company = _mapper.Map<Company>(value);
            _serviceCompany.Update(company);
            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            _serviceCompany.Delete(guid);
            return Ok();
        }
    }

}