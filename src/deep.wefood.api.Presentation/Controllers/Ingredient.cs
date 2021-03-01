
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
    public class IngredientController : ControllerBase
    {
        private IServiceIngredient _serviceIngredient;
        private IMapper _mapper;

        public IngredientController(IMapper mapper, IServiceIngredient serviceIngredient)
        {
            _serviceIngredient = serviceIngredient;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var ingredient = _serviceIngredient.FindByGuid(guid);
            var dto = _mapper.Map<IngredientDto>(ingredient);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [HttpGet, Route("~/product/{productGuid}/ingredients")]
        public IActionResult GetByProduct(string productGuid)
        {
            var ingredients = _serviceIngredient.FindByProduct(productGuid);
            var dto = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Post([FromBody] IngredientDto value)
        {
            var ingredient = _mapper.Map<Ingredient>(value);
            _serviceIngredient.Add(ingredient);
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut]
        public IActionResult Put(IngredientDto value)
        {
            var ingredient = _mapper.Map<Ingredient>(value);
            _serviceIngredient.Add(ingredient);
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            _serviceIngredient.Delete(guid);
            return Ok();
        }
        #endregion DELETE

    }
}