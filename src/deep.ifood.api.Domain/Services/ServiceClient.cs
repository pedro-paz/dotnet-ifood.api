using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Interfaces.Services;

namespace deep.ifood.api.Services
{
    public class ServiceClient : ServiceBase<Client>, IServiceClient
    {

        public ServiceClient(IRepository<Client> repository) : base(repository)
        {
        }


    }
}
