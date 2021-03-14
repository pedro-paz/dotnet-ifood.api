﻿
using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceCompany : IServiceCompany
    {
        private IRepository<Company> _companyRepository;

        public ServiceCompany(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Add(Company company)
        {
            _companyRepository.Add(company);
            _companyRepository.SaveChanges();

        }

        public void Delete(string guid)
        {
            var company = _companyRepository.Query(company => company.Guid == guid).FirstOrDefault();

            if (company == null)
                throw new System.Exception("Company not found");

            _companyRepository.Delete(company);
            _companyRepository.SaveChanges();
        }

        public Company FindByGuid(string guid)
        {
            var company = _companyRepository.Query(company => company.Guid == guid).FirstOrDefault();

            if (company == null)
                throw new System.Exception("Company not found");

            return company;
        }

        public void Update(Company newCompany)
        {
            var oldCompany = _companyRepository.Query(user => user.Guid == newCompany.Guid).FirstOrDefault();

            if (oldCompany == null)
                throw new System.Exception("Company not found");

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
            return _companyRepository.FindAll();
        }
    }
}
