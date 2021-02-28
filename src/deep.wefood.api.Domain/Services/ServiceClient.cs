using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceClient : ServiceBase<Client>, IServiceClient
    {

        public ServiceClient(IRepository<Client> repository) : base(repository)
        {
        }


    }
}
