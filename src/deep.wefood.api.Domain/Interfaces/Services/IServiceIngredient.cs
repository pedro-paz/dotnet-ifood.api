using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceIngredient
    {
        IEnumerable<Ingredient> FindByProduto(Product produto);
        Ingredient FindByGuid(string guid);
    }
}
