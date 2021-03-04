using System.Collections.Generic;

namespace deep.wefood.api.Presentation.Dto
{
    public class OrderDto
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string GuidUser { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}