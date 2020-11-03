using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingJwtAuthentication.Entities;
using SecuringWebApiUsingJwtAuthentication.Helpers;
using SecuringWebApiUsingJwtAuthentication.Interfaces;
using SecuringWebApiUsingJwtAuthentication.Requests;
using SecuringWebApiUsingJwtAuthentication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomersDbContext _customersDbContext;

        public CustomerService(CustomersDbContext customersDbContext)
        {
            _customersDbContext = customersDbContext;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var passwordHash = HashingHelper.CalculateSHA256Hash(loginRequest.Password);
            var customer = _customersDbContext.Customers.SingleOrDefault(customer => 
                                                                            customer.Active && 
                                                                            customer.Username == loginRequest.Username && 
                                                                            customer.Password == passwordHash);

            if(customer == null)
            {
                return null;
            }

            var token = await Task.Run(() => TokenHelper.GenerateToken(customer));

            return new LoginResponse { Username = customer.Username, FirstName = customer.FirstName, LastName = customer.LastName, Token = token };
        }
    }
}
