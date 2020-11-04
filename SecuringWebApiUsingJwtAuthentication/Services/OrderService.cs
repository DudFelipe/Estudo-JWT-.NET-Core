using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingJwtAuthentication.Entities;
using SecuringWebApiUsingJwtAuthentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Services
{
    public class OrderService : IOrderServices
    {
        private readonly CustomersDbContext _customersDbContext;

        public OrderService(CustomersDbContext customersDbContext)
        {
            _customersDbContext = customersDbContext;
        }

        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = await _customersDbContext.Orders.Where(order => order.CustomerId == id).ToListAsync();

            return orders;
        }
    }
}
