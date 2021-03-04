using System.Collections.Generic;
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
    public class ProductController : ControllerBase
    {
        private IServiceProduct _serviceProduct;
        private IMapper _mapper;

        public ProductController(IMapper mapper, IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var order = _serviceProduct.FindByGuid(guid);
            var dto = _mapper.Map<ProductDto>(order);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [HttpGet, Route("~/company/{companyGuid}/products")]
        public IActionResult GetByCompany(string companyGuid)
        {
            var products = _serviceProduct.FindByCompany(companyGuid);
            var dto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto value)
        {
            var product = _mapper.Map<Product>(value);
            _serviceProduct.Update(product);
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut]
        public IActionResult Put(ProductDto value)
        {
            var product = _mapper.Map<Product>(value);
            _serviceProduct.Add(product);
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            _serviceProduct.Delete(guid);
            return Ok();
        }
        #endregion DELETE

    }
}