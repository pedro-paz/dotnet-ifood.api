using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceProduct
    {
        IEnumerable<Product> FindByName(string name);
        Product FindByGuid(string guid);
        void Delete(string guidProduct);
        void Update(Product product);
        void Add(Product product);
        IEnumerable<Product> FindByCompany(string companyGuid);
    }
}
