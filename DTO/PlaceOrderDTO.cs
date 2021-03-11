using System.Collections.Generic;
using Models;

namespace DTO
{
    public class PlaceOrderDTO
    {
        public int order_id {get; set;}
        public int Customer_Id {get; set;}
        public int Product_Id {get; set;}
    }
}