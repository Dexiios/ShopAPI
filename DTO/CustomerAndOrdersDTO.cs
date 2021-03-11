using System.Collections.Generic;
using Models;
using DTO;

namespace DTO
{
    public class CustomerAndOrdersDTO : CustomerDTO
    {
        public List<PlaceOrderDTO> Orders { get; set; }
    }
}