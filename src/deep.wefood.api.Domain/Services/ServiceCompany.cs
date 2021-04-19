
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceCompany : IServiceCompany
    {
        private IRepository<CompanyDetail> _companyRepository;
        private IMapper _mapper;

        public ServiceCompany(IRepository<CompanyDetail> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public void Add(CompanyDetail company)
        {
            _companyRepository.Add(company);
            _companyRepository.SaveChanges();
        }

        public void AddRange(IEnumerable<CompanyDetail> companies)
        {
            companies.ToList().ForEach(company => _companyRepository.Add(company));
            _companyRepository.SaveChanges();
        }

        public void Delete(string guid)
        {
            var company = _companyRepository.Query(company => company.Guid == guid).FirstOrDefault();

            _companyRepository.Delete(company);
            _companyRepository.SaveChanges();
        }

        public CompanyDetail FindByGuid(string guid)
        {
            var company = _companyRepository.Query(company => company.Guid == guid).FirstOrDefault();

            return company;
        }

        public void Update(CompanyDetail newCompany)
        {
            var oldCompany = _companyRepository.Query(user => user.Guid == newCompany.Guid).FirstOrDefault();

            oldCompany.Name = newCompany.Name;

            _companyRepository.Update(oldCompany);
            _companyRepository.SaveChanges();
        }

        public void SaveChanges()
        {
            _companyRepository.SaveChanges();
        }

        public IEnumerable<Company> FindAll()
        {
            return _companyRepository
                .Select(x => new Company()
                {
                    Name = x.Name,
                    Guid = x.Guid,
                    MinimumOrderValue = x.MinimumOrderValue,
                    Rating = x.Rating
                });
        }
    }
}
