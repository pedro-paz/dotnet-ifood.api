using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Interfaces.Services
{
    public interface IServiceOrder
    {
        IEnumerable<Order> GetPedidosCliente(int idCliente);
        IEnumerable<Order> GetPedidosRestaurante(int idRestaurante);
    }
}
