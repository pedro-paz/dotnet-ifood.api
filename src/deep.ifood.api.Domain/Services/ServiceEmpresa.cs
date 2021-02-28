
using System.Linq;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Interfaces.Services;

namespace deep.ifood.api.Services
{
    public class ServiceCompany : ServiceBase<Company>, IServiceCompany
    {

        public ServiceCompany(IRepository<Company> repository) : base(repository)
        {
        }


        public Company FindByGuid(string guid)
        {
            return _repository.Query(x => x.Guid == guid).FirstOrDefault();
        }

        public Company FindByUser(User usuario)
        {
            return new Company();
        }
    }
}
