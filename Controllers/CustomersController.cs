using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;

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
    }
}