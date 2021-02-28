using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Interfaces.Services;

namespace deep.ifood.api.Services
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
