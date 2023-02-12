using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopManagement.API.Models;

namespace ShopManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using (var context = new ShopEFContext())
            {
                var customers = await context.Customers.ToListAsync();
                return customers;
            }
        }

        // TODO : Get Cutomers Who Buy the Max Products Prices
        [HttpGet("/GetCustomerMaxBuying")]
        public async Task<IEnumerable<Customer>> GetCustomerMaxBuying()
        {
            using (var context = new ShopEFContext())
            {
                var MaxCustomers =  context.Customers.OrderByDescending(o => o.Orders.SelectMany(x => x.OrderProducts).Sum(s => s.Price * s.Quantity));
                return MaxCustomers;
            }
        }
    }
}
