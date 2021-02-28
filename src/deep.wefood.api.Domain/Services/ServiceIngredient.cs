using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceIngredient : ServiceBase<Ingredient>, IServiceIngredient
    {

        public ServiceIngredient(IRepository<Ingredient> repository) : base(repository)
        {
        }

        public Ingredient FindByGuid(string guid)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ingredient> FindByProduto(Product produto)
        {
            throw new System.NotImplementedException();
        }
    }
}
