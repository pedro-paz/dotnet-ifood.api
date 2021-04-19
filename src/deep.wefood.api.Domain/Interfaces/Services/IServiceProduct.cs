using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceProduct
    {
        IEnumerable<ProductDetail> FindByName(string name);
        ProductDetail FindByGuid(string guid);
        void Delete(string guidProduct);
        void Update(ProductDetail product);
        void Add(CompanyDetail company, ProductDetail product);
        IEnumerable<Product> FindByCompany(string companyGuid);
    }
}
