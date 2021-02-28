using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Services;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceUser
    {
        User Auth(string email, string password);
        User FindByGuid(string guid);
        void Update(User User);
        void Delete(string guid);
        void Add(User user);
    }
}
