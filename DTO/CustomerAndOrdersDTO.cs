using System.Collections.Generic;
using Models;
using DTO;

namespace DTO
{
    public class CustomerOrdersListDTO : CustomerDTO
    {
        public List<OrderDTO> Orders { get; set; }
    }
}