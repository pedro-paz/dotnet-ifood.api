using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {

        public ServiceProduct(IRepository<Product> repository) : base(repository)
        {
        }

        public IEnumerable<Product> FindByEmpresa(Company empresa)
        {
            return _repository.Query(x => x.IdEmpresa == empresa.Id);
        }

        public Product FindByGuid(string guid)
        {
            return _repository.Query(x => x.Guid == guid).FirstOrDefault();
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return _repository.Query(x => x.Nome == name);
        }


    }
}
