using System;
using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Interfaces.Services;

namespace deep.ifood.api.Services
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
