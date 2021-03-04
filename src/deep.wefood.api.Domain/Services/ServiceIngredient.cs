using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceIngredient : IServiceIngredient
    {
        private IRepository<Ingredient> _ingredientRepository;
        private IRepository<Product> _productRepository;

        public ServiceIngredient(IRepository<Ingredient> ingredientRepository, IRepository<Product> productRepository)
        {
            _ingredientRepository = ingredientRepository;
            _productRepository = productRepository;
        }

        public void Add(Ingredient ingredient)
        {
            var product = _productRepository.Query(x => x.Guid == ingredient.Product?.Guid).FirstOrDefault();

            if (product == null)
                throw new System.Exception("Product not found");

            product.Ingredients.Add(ingredient);
            _productRepository.SaveChanges();
        }

        public void Delete(string guid)
        {
            var ingredient = _ingredientRepository.Query(ingredient => ingredient.Guid == guid).FirstOrDefault();

            if (ingredient == null)
                throw new System.Exception("Ingredient not found");

            _ingredientRepository.Delete(ingredient);
        }

        public Ingredient FindByGuid(string guid)
        {
            var ingredient = _ingredientRepository.Query(ingredient => ingredient.Guid == guid).FirstOrDefault();

            if (ingredient == null)
                throw new System.Exception("Ingredient not found");

            return ingredient;
        }

        public IEnumerable<Ingredient> FindByProduct(string productGuid)
        {
            var product = _productRepository.Query(x => x.Guid == productGuid).FirstOrDefault();

            if (product == null)
                throw new System.Exception("Product not found");

            return product.Ingredients;

        }

        public void Update(Ingredient ingredient)
        {
            var entity = _ingredientRepository.Query(x => x.Guid == ingredient.Guid).FirstOrDefault();

            if (entity == null)
                throw new System.Exception("Ingredient not found");

            entity.Name = ingredient.Name;
            entity.Description = ingredient.Description;

            _ingredientRepository.Update(entity);
            _ingredientRepository.SaveChanges();
        }
    }
}
