using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private IProductRepository _productRepository;
        private IRepository<CompanyDetail> _companyRepository;
        private IRepository<ComplementGroup> _complementGroupsRepository;

        public ServiceProduct(IProductRepository productRepository, IRepository<CompanyDetail> companyRepository, IRepository<ComplementGroup> complementGroupsRepository)
        {
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _complementGroupsRepository = complementGroupsRepository;
        }

        public void Add(CompanyDetail company, ProductDetail product)
        {
            company.Products = company.Products ?? new List<ProductDetail>();
            company.Products.Add(product);
            _companyRepository.Update(company);
            _companyRepository.SaveChanges();
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

            var products = _productRepository
                .Query(x => x.IdCompany == company.Id)
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Guid = x.Guid
                });

            return products;
        }

        public ProductDetail FindByGuid(string guid)
        {
            var product = _productRepository.FindProductDetail(guid);

            if (product == null)
                throw new System.Exception("Product not found");

            return product;
        }

        public IEnumerable<ProductDetail> FindByName(string name)
        {
            return _productRepository.Query(x => x.Name == name);
        }

        public void Update(ProductDetail product)
        {
            throw new System.NotImplementedException();
        }
    }
}
