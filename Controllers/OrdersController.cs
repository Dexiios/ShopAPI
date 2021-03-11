using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using Models;
using Microsoft.EntityFrameworkCore;
using DTO;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly Context _context;
        public OrdersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> Get_Orders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> Get_Orders_By_Id(int id)
        {
            var ord = await _context.Orders.FindAsync(id);

            if(ord == null)
            {
                return NotFound();
            }
            else
            {
                return ord;
            }
            
        }
        
        [HttpPost]
        public async Task<ActionResult<Orders>> Add_Order(Orders ord)
        {
            await _context.Orders.AddAsync(ord);
            await _context.SaveChangesAsync();

            return ord;
        }

        [HttpPost("Place Order")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Place_Order(OrderDTO request)
        {
            
            var order = new Orders()
            {
                Product_Id = request.Product_Id,
                Customer_Id = request.Customer_Id
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            

            return CreatedAtAction("Get_Orders", new { id = order.Id }, order);
        }
    }
}