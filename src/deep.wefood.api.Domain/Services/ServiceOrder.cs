using System;
using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Interfaces.Services;

namespace deep.wefood.api.Services
{
    public class ServiceOrder : IServiceOrder
    {
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;

        public ServiceOrder(IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
        }

        public void Delete(string guidOrder)
        {
            var order = _orderRepository.Query(x => x.Guid == guidOrder).FirstOrDefault();
            _orderRepository.Delete(order);
            _orderRepository.SaveChanges();
        }

        public Order FindByGuid(string guidOrder)
        {
            var order = _orderRepository.Query(x => x.Guid == guidOrder).FirstOrDefault();
            return order;
        }

        public IEnumerable<Order> FindByUser(string guidUser)
        {
            var user = _userRepository.Query(x => x.Guid == guidUser).FirstOrDefault();
            return user.Orders;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
