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
    public class OrderController : ControllerBase
    {
        private IServiceOrder _serviceOrder;
        private IMapper _mapper;

        public OrderController(IMapper mapper, IServiceOrder serviceOrder)
        {
            _serviceOrder = serviceOrder;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var order = _serviceOrder.FindByGuid(guid);
            var dto = _mapper.Map<OrderDto>(order);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }

        [HttpGet, Route("~/user/{userGuid}/orders")]
        public IActionResult GetByUser(string userGuid)
        {
            var orders = _serviceOrder.FindByUser(userGuid);
            var dto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return dto != null ? Ok(JsonConvert.SerializeObject(dto)) : NoContent();
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto value)
        {
            var order = _mapper.Map<Order>(value);
            _serviceOrder.Update(order);
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut]
        public IActionResult Put(OrderDto value)
        {
            var order = _mapper.Map<Order>(value);
            _serviceOrder.Add(order);
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            _serviceOrder.Delete(guid);
            return Ok();
        }
        #endregion DELETE

    }
}