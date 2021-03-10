using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Product_name { get; set; }
        public int Product_price { get; set; }

    }
}