using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneORder(int id);
        void complate(int id);
        void SaveOrder(Order order);
        int NumberOfInProccess { get; }
    }
}
