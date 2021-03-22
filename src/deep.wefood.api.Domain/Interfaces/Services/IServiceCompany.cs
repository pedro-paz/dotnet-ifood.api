using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceCompany
    {
        Company FindByGuid(string guid);
        void Update(Company newCompany);
        void Delete(string guid);
        void Add(Company company);
        void AddRange(IEnumerable<Company> company);
        void SaveChanges();
        IEnumerable<Company> FindAll();
    }
}
