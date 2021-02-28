using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceProduct
    {
        IEnumerable<Product> FindByName(string name);
        IEnumerable<Product> FindByEmpresa(Company empresa);
        Product FindByGuid(string guid);

    }
}
