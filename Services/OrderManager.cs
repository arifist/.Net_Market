using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProccess => _manager.Order.NumberOfInProccess;

        public void complate(int id)
        {
            _manager.Order.complate(id);
            _manager.Save();

        }

        public Order? GetOneORder(int id)
        {
            return _manager.Order.GetOneORder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}
