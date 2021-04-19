using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceCompany
    {
        CompanyDetail FindByGuid(string guid);
        void Update(CompanyDetail newCompany);
        void Delete(string guid);
        void Add(CompanyDetail company);
        void AddRange(IEnumerable<CompanyDetail> company);
        void SaveChanges();
        IEnumerable<Company> FindAll();
    }
}
