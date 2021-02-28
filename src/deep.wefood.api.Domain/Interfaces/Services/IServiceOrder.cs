using System.Collections.Generic;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Interfaces.Services
{
    public interface IServiceOrder
    {
        IEnumerable<Order> GetPedidosCliente(int idCliente);
        IEnumerable<Order> GetPedidosRestaurante(int idRestaurante);
    }
}
