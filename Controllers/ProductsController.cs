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

    public class ProductsController : ControllerBase
    {
        private readonly Context _context;
        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get_Orders()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Add_Order(Products pro)
        {
            await _context.Products.AddAsync(pro);
            await _context.SaveChangesAsync();

            return pro;
        }
    }
}