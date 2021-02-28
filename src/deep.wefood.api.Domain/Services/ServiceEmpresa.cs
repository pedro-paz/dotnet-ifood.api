
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
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
