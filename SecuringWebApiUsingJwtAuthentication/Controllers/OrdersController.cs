using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuringWebApiUsingJwtAuthentication.Interfaces;
using SecuringWebApiUsingJwtAuthentication.Services;

namespace SecuringWebApiUsingJwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet()]
        [Authorize(Policy = "OnlyNonBlockedCustomer")]
        public async Task<IActionResult> Get()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim == null)
            {
                return Unauthorized("Invalid customer");
            }

            var orders = await _orderServices.GetOrdersByCustomerId(int.Parse(claim.Value));

            if(orders == null || !orders.Any())
            {
                return BadRequest($"No order was found");
            }

            return Ok(orders);
        }
    }
}
