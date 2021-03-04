using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceOrder
    {
        Order FindByGuid(string guid);
        IEnumerable<Order> FindByUser(string guidUser);
        void Add(Order order);
        void Delete(string guidOrder);
        void Update(Order order);
    }
}
