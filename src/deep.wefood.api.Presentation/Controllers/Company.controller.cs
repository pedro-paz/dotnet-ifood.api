using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Presentation.Dto;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var companies = _serviceCompany.FindAll();
            var dtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companies != null ? Ok(JsonConvert.SerializeObject(dtos)) : NoContent();
        }

        [HttpGet("{guid}")]
        [AllowAnonymous]
        public IActionResult Get(string guid)
        {
            var company = _serviceCompany.FindByGuid(guid);
            var dto = _mapper.Map<CompanyDto>(company);
            return company != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CompanyDto value)
        {
            var entity = _mapper.Map<Company>(value);
            _serviceCompany.Add(entity);
            return Ok();
        }

        [HttpPost, Route("/companies")]
        public IActionResult Post([FromBody] IEnumerable<CompanyDto> value)
        {
            var entity = _mapper.Map<IEnumerable<Company>>(value);
            _serviceCompany.AddRange(entity);
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