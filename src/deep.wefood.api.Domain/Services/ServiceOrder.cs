using System;
using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceOrder : ServiceBase<Order>, IServiceOrder
    {

        public ServiceOrder(IRepository<Order> repository) : base(repository)
        {

        }


        public IEnumerable<Order> GetPedidosCliente(int idCliente)
        {
            return _repository.Query(x => x.IdCliente == idCliente);
        }

        public IEnumerable<Order> GetPedidosRestaurante(int idRestaurante)
        {
            throw new NotImplementedException();
        }
    }
}
