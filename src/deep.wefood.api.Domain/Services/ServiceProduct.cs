using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private IRepository<Product> _productRepository;
        private IRepository<Company> _companyRepository;

        public ServiceProduct(IRepository<Product> productRepository, IRepository<Company> companyRepository)
        {
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        public void Delete(string guidProduct)
        {
            var product = _productRepository.Query(x => x.Guid == guidProduct).FirstOrDefault();

            if (product == null)
                throw new System.Exception("Product not found");

            _productRepository.Delete(product);
            _productRepository.SaveChanges();
        }

        public IEnumerable<Product> FindByCompany(string companyGuid)
        {
            var company = _companyRepository.Query(x => x.Guid == companyGuid).FirstOrDefault();

            if (company == null)
                throw new System.Exception("Company not found");

            return company.Products;
        }

        public IEnumerable<Product> FindByEmpresa(Company empresa)
        {
            return _productRepository.Query(x => x.IdCompany == empresa.Id);
        }

        public Product FindByGuid(string guid)
        {
            return _productRepository.Query(x => x.Guid == guid).FirstOrDefault();
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return _productRepository.Query(x => x.Name == name);
        }

        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
