using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Interfaces.Services
{
    public interface IServiceCompany
    {
        Company FindByGuid(string guid);
        Company FindByUser(User usuario);
    }
}
