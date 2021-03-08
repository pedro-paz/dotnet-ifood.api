using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Domain.Services
{
    public class ServiceComplement : IServiceComplement
    {
        private IRepository<Complement> _repositoryComplement;

        public ServiceComplement(IRepository<Complement> repositoryComplement)
        {
            _repositoryComplement = repositoryComplement;
        }

        public void Add(Complement complement)
        {
            _repositoryComplement.Add(complement);
            _repositoryComplement.SaveChanges();
        }

        public void Delete(string guidComplement)
        {
            var complement = _repositoryComplement.Query(x => x.Guid == guidComplement).FirstOrDefault();

            if (complement == null)
                throw new System.Exception("Complement not found");

            _repositoryComplement.Delete(complement);
            _repositoryComplement.SaveChanges();
        }

        public Complement FindByGuid(string guidComplement)
        {
            var complement = _repositoryComplement.Query(x => x.Guid == guidComplement).FirstOrDefault();
            return complement;
        }


        public void Update(Complement complement)
        {
            var entity = _repositoryComplement.Query(x => x.Guid == complement.Guid).FirstOrDefault();
            entity.Name = complement.Name;
            entity.Description = complement.Description;
            _repositoryComplement.Update(complement);
            _repositoryComplement.SaveChanges();
        }
    }
}