using SecuringWebApiUsingJwtAuthentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Interfaces
{
    public interface IOrderServices
    {
        Task<List<Order>> GetOrdersByCustomerId(int id);
    }
}
