using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceIngredient
    {
        IEnumerable<Ingredient> FindByProduct(string productGuid);
        Ingredient FindByGuid(string guid);
        void Add(Ingredient ingredient);
        void Delete(string guid);
        void Update(Ingredient ingredient);
    }
}
