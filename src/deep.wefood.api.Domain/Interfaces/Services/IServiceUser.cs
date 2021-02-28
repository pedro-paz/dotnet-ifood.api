using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceUser
    {
        User Auth(string email, string password);

        User FindByGuid(string guid);
    }
}
