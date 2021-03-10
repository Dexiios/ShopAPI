using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }

    }
}