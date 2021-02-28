using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceCompany
    {
        Company FindByGuid(string guid);
        Company FindByUser(User usuario);
    }
}
