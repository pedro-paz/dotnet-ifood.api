using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Interfaces.Services
{
    public interface IServiceIngredient
    {
        IEnumerable<Ingredient> FindByProduto(Product produto);
        Ingredient FindByGuid(string guid);
    }
}
