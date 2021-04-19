using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Domain.Interfaces.Generics
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindProductDetail(string guidProduct);
    }
}