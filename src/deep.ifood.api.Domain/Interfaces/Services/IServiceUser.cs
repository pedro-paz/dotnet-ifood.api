using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Interfaces.Services
{
    public interface IServiceUser
    {
        User Auth(string email, string password);

        User FindByGuid(string guid);
    }
}
