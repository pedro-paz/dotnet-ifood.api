using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Services;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceUser
    {
        User Authenticate(string email, string password);
        User FindByGuid(string guid);
        User FindByEmail(string email);
        void Update(User User);
        void Delete(string guid);
        void Add(User user);
    }
}
