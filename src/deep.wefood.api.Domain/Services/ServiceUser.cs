using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;
using System.Linq;

namespace deep.wefood.api.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {

        public ServiceUser(IRepository<User> repository) : base(repository)
        {
        }

        public User Auth(string email, string senha)
        {
            return _repository.Query(x =>
              x.Email.Trim().ToLower() == email?.Trim().ToLower() &&
              x.Senha.Trim().ToLower() == senha?.Trim().ToLower()
            ).FirstOrDefault();
        }

        public User FindByGuid(string guid)
        {
            return _repository.Query(x =>
              x.Guid.ToLower() == guid.ToLower()
            ).FirstOrDefault();
        }

    }
}
