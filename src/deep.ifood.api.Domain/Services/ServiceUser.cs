using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Interfaces.Services;
using System.Linq;

namespace deep.ifood.api.Services
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
