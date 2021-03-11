using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<ActionResult<Customers>> Add_Customer(Customers custo)
        {
            await _context.Customers.AddAsync(custo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get_Customers", new { id = custo.Id }, custo);
        }
    }
}