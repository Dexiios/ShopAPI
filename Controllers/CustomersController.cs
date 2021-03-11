using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using Models;
using Microsoft.EntityFrameworkCore;
using DTO;
using System.Linq;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomersController : ControllerBase
    {
        private readonly Context _context;
        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Get_Customers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get_Customers_by_Id(int id)
        {
            
            var ord = from orders in _context.Orders
            join products in _context.Products on orders.Product_Id equals products.Id
            join customers in _context.Customers on orders.Customer_Id equals customers.Id
            select new PlaceOrderDTO
            {
                order_id = orders.Id,
                Customer_Id = customers.Id,
                Product_Id = products.Id
            };

            var cust = from customers in _context.Customers
            join order in _context.Orders on customers.Id equals order.Customer_Id
            select new CustomerAndOrdersDTO
            {
                customer_id = customers.Id,
                First_name = customers.First_name,
                Last_name = customers.Last_name,
                Orders = ord.Where(x => x.Customer_Id == customers.Id).ToList()
            };

            var customer = cust.ToList().Find(x => x.customer_id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return customer;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customers>> Add_Customer(Customers custo)
        {
            await _context.Customers.AddAsync(custo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get_Customers", new { id = custo.Id }, custo);
        }
    }
}