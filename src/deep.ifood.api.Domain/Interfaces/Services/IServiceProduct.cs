using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Interfaces.Services
{
    public interface IServiceProduct
    {
        IEnumerable<Product> FindByName(string name);
        IEnumerable<Product> FindByEmpresa(Company empresa);
        Product FindByGuid(string guid);

    }
}
