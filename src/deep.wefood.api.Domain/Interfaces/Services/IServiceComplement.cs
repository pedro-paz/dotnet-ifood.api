using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceComplement
    {
        Complement FindByGuid(string guid);
        void Add(Complement ingredient);
        void Delete(string guid);
        void Update(Complement ingredient);
    }
}
