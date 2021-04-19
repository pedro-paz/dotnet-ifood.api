using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Domain.Interfaces.Generics
{
    public interface IProductRepository : IRepository<ProductDetail>
    {
        ProductDetail FindProductDetail(string guidProduct);
    }
}